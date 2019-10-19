namespace WebApp.Transversales.Extensions
{
    using Enum;
    using Operator;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;

    /// <summary>
    ///Clase de ayuda de imagen
    /// </summary>
    public static class ImageHelper
    {
        #region Fields

        /// <summary>
        /// Formato de imagen permitida
        /// </summary>
        public const string AllowExt = ".jpeg|.jpg|.bmp|.gif|.png";

        #endregion Fields

        #region Methods



        /// <summary>
        /// Determine si son iguales comparando los dos bytes [] del mapa de bits.
        /// </summary>
        /// <param name="originalImage">Imagen original</param>
        /// <param name="compareImage">Imágenes para comparar</param>
        /// <returns>Resultado de la comparación</returns>
        public static bool CompareByArray(this Bitmap originalImage, Bitmap compareImage)
        {
            /*
            *Referencia：
            *1. http://www.cnblogs.com/zgqys1980/archive/2009/07/13/1522546.html
            */
            IntPtr _result = new IntPtr(-1);
            MemoryStream _ms = new MemoryStream();

            try
            {
                originalImage.Save(_ms, ImageFormat.Png);
                byte[] _b1Array = _ms.ToArray();
                _ms.Position = 0;
                compareImage.Save(_ms, ImageFormat.Png);
                byte[] _b2Array = _ms.ToArray();
                _result = memcmp(_b1Array, _b2Array, new IntPtr(_b1Array.Length));
            }
            finally
            {
                _ms.Close();
            }

            return _result.ToInt32() == 0;
        }

        /// <summary>
        /// Determine si son iguales comparando los dos bits ToBase64String del mapa de bits.
        /// </summary>
        /// <param name="originalImage">Imagen original</param>
        /// <param name="compareImage">Imágenes para comparar</param>
        /// <returns>Resultado de la comparación</returns>
        public static bool CompareByBase64(this Bitmap originalImage, Bitmap compareImage)
        {
            /*
            *Referencia
            *1. http://blogs.msdn.com/b/domgreen/archive/2009/09/06/comparing-two-images-in-c.aspx
            */
            string _b1Base64String, _b2Base64String;
            MemoryStream _ms = new MemoryStream();

            try
            {
                originalImage.Save(_ms, ImageFormat.Png);
                _b1Base64String = Convert.ToBase64String(_ms.ToArray());
                _ms.Position = 0;
                compareImage.Save(_ms, ImageFormat.Png);
                _b2Base64String = Convert.ToBase64String(_ms.ToArray());
            }
            finally
            {
                _ms.Close();
            }

            return _b1Base64String.Equals(_b2Base64String);
        }

        /// <summary>
        /// Determine si son iguales comparando los dos memcmps del mapa de bits.
        /// </summary>
        /// <param name="originalImage">Imagen original</param>
        /// <param name="compareImage">Imágenes para comparar</param>
        /// <returns>比较结果</returns>
        public static bool CompareByMemCmp(this Bitmap originalImage, Bitmap compareImage)
        {
            /*
             *Referencia：
             *1. http://stackoverflow.com/questions/2031217/what-is-the-fastest-way-i-can-compare-two-equal-size-bitmaps-to-determine-whethe
             */
            if((originalImage == null) != (compareImage == null)) return false;

            if(originalImage.Size != compareImage.Size) return false;

            BitmapData _bdata1 = originalImage.LockBits(new Rectangle(new Point(0, 0), originalImage.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData _bdata2 = compareImage.LockBits(new Rectangle(new Point(0, 0), compareImage.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr _bd1scan0 = _bdata1.Scan0;
                IntPtr _bd2scan0 = _bdata2.Scan0;
                int _stride = _bdata1.Stride;
                int _len = _stride * originalImage.Height;
                return memcmp(_bd1scan0, _bd2scan0, _len) == 0;
            }
            finally
            {
                originalImage.UnlockBits(_bdata1);
                compareImage.UnlockBits(_bdata2);
            }
        }

        /// <summary>
        /// Determine si los dos son iguales comparando los colores de píxeles de ambos mapas de bits
        /// </summary>
        /// <param name="originalImage">Imagen original</param>
        /// <param name="compareImage">Imágenes para comparar</param>
        /// <returns>Resultado de la comparación</returns>
        public static bool CompareByPixel(this Bitmap originalImage, Bitmap compareImage)
        {
            /*
             *Referencia：
             *1. http://blogs.msdn.com/b/domgreen/archive/2009/09/06/comparing-two-images-in-c.aspx
             */
            bool _flag = false;

            if(originalImage.Width == compareImage.Width && originalImage.Height == compareImage.Height)
            {
                _flag = true;
                Color _pixel1;
                Color _pixel2;

                for(int i = 0; i < originalImage.Width; i++)
                {
                    for(int j = 0; j < originalImage.Height; j++)
                    {
                        _pixel1 = originalImage.GetPixel(i, j);
                        _pixel2 = compareImage.GetPixel(i, j);

                        if(_pixel1 != _pixel2)
                        {
                            _flag = false;
                            break;
                        }
                    }
                }
            }

            return _flag;
        }

        /// <summary>
        /// Comprime la imagen al tamaño especificado
        /// </summary>
        /// <param name="originalImagePath">Imagen a comprimir</param>
        /// <param name="size">Tamaño esperado después de la compresión</param>
        public static void CompressPhoto(string originalImagePath, int size)
        {
            int _count = 0;
            FileInfo _imgFile = new FileInfo(originalImagePath);
            long _imgLength = _imgFile.Length;

            while(_imgLength > size * 1024 && _count < 10)
            {
                string _directory = _imgFile.Directory.FullName;
                string _tempFile = Path.Combine(_directory, Guid.NewGuid().ToString() + "." + _imgFile.Extension);
                _imgFile.CopyTo(_tempFile, true);
                KiSaveAsJPEG(_tempFile, originalImagePath, 70);

                try
                {
                    File.Delete(_tempFile);
                }
                catch { }

                _count++;
                _imgFile = new FileInfo(originalImagePath);
                _imgLength = _imgFile.Length;
            }
        }

        /// <summary>
        /// Genera miniaturas sin marcas de agua
        /// </summary>
        /// <param name="originalImagePath">Archivo fuente</param>
        /// <param name="width">Ancho de la miniatura</param>
        /// <param name="height">Altura de la miniatura</param>
        /// <param name="destfile">Miniatura guardar ubicación</param>
        public static void CreateSmallPhoto(string originalImagePath, int width, int height, string destfile)
        {
            using(Image sourceImg = Image.FromFile(originalImagePath))
            {
                ImageFormat _imageFormat = sourceImg.RawFormat;
                Size _imageCutSize = CutRegion(width, height, sourceImg);
                using(Bitmap sourceBmp = new Bitmap(width, height))
                {
                    using(Graphics graphics = Graphics.FromImage(sourceBmp))
                    {
                        graphics.Clear(Color.White);
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        int _startX = (sourceImg.Width - _imageCutSize.Width) / 2;
                        int _startY = (sourceImg.Height - _imageCutSize.Height) / 2;
                        graphics.DrawImage(sourceImg, new Rectangle(0, 0, width, height),
                                           _startX, _startY, _imageCutSize.Width, _imageCutSize.Height, GraphicsUnit.Pixel);
                    }
                    SetWaterMarkImageQuality(sourceBmp, destfile, _imageFormat);
                }
            }
        }

        /// <summary>
        /// Genera miniaturas sin marcas de agua
        /// </summary>
        /// <param name="sourceImageFile">Archivo fuente</param>
        /// <param name="width">Ancho de la miniatura</param>
        /// <param name="height">Altura de la miniatura</param>
        /// <param name="destfile">Miniatura guardar ubicación</param>
        /// <param name="cMode">Modo de recorte</param>
        public static void CreateSmallPhoto(string sourceImageFile, int width, int height, string destfile, CutType cMode)
        {
            using (Image _sourceImg = Image.FromFile(sourceImageFile))
            {
                if (width <= 0)
                    width = _sourceImg.Width;

                if (height <= 0)
                    height = _sourceImg.Height;

                int _towidth = width,
                    _toheight = height;

                switch (cMode)
                {
                    case CutType.CutWH://Especifique el zoom de alto y ancho (posiblemente deformado)
                        break;

                    case CutType.CutW://Especificar ancho, alta relación
                        _toheight = _sourceImg.Height * width / _sourceImg.Width;
                        break;

                    case CutType.CutH://Especificar alta y amplia proporcional
                        _towidth = _sourceImg.Width * height / _sourceImg.Height;
                        break;

                    case CutType.CutNo: //El zoom no se recorta
                        int maxSize = (width >= height ? width : height);

                        if (_sourceImg.Width >= _sourceImg.Height)
                        {
                            _towidth = maxSize;
                            _toheight = _sourceImg.Height * maxSize / _sourceImg.Width;
                        }
                        else
                        {
                            _toheight = maxSize;
                            _towidth = _sourceImg.Width * maxSize / _sourceImg.Height;
                        }

                        break;

                    default:
                        break;
                }

                width = _towidth;
                height = _toheight;
                ImageFormat _imageFormat = _sourceImg.RawFormat;
                Size _imageCutSize = new Size(width, height);

                if (cMode != CutType.CutNo)
                    _imageCutSize = CutRegion(width, height, _sourceImg);

                using (Bitmap sourceBmp = new Bitmap(width, height))
                {
                    using (Graphics graphics = Graphics.FromImage(sourceBmp))
                    {
                        graphics.Clear(Color.White);
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        int _startX = (_sourceImg.Width - _imageCutSize.Width) / 2;
                        int _startY = (_sourceImg.Height - _imageCutSize.Height) / 2;
                        graphics.DrawImage(_sourceImg, new Rectangle(0, 0, width, height),
                                           _startX, _startY, _imageCutSize.Width, _imageCutSize.Height, GraphicsUnit.Pixel);
                    }
                    SetWaterMarkImageQuality(sourceBmp, destfile, _imageFormat);
                }
            }
        }

        /// <summary>
        /// Obtener formato de imagen
        /// </summary>
        /// <param name="imagePath">Camino de la imagen</param>
        /// <returns>ImageFormat</returns>
        public static ImageFormat GetImageFormat(this string imagePath)
        {
            Image _sourceImage = Image.FromFile(imagePath);
            ImageFormat _sourceImageFormat = _sourceImage.RawFormat;
            return _sourceImageFormat;
        }

        /// <summary>
        /// Combinar imágenes
        /// </summary>
        /// <param name="mergerImageWidth">Fusiona el ancho de la imagen</param>
        /// <param name="mergerImageHeight">La altura de la imagen fusionada.</param>
        /// <param name="imageX">La coordenada X de la esquina superior izquierda de la imagen dibujada</param>
        /// <param name="imageY">La coordenada Y de la esquina superior izquierda de la imagen dibujada</param>
        /// <param name="backgroundColor">El color de fondo de la imagen fusionada.</param>
        /// <param name="maps">La colección de imágenes que necesitan ser dibujadas.</param>
        /// <returns>Cuadro dibujado</returns>
        public static Bitmap MergerImage(int mergerImageWidth, int mergerImageHeight, int imageX, int imageY, Color backgroundColor, params Bitmap[] maps)
        {
            int _imageCount = maps.Length;
            //Cree un objeto de imagen para mostrar, establezca el ancho de acuerdo con el número de parámetros
            Bitmap _drawImage = new Bitmap(mergerImageWidth, mergerImageHeight);
            Graphics _graphics = Graphics.FromImage(_drawImage);

            try
            {
                //Borrar el lienzo, el fondo se establece en blanco
                _graphics.Clear(Color.White);

                for(int j = 0; j < _imageCount; j++)
                {
                    _graphics.DrawImage(maps[j], j * imageX, imageY, maps[j].Width, maps[j].Height);
                }
            }
            finally
            {
                _graphics.Dispose();
            }

            return _drawImage;
        }

        /// <summary>
        /// Convertir cadenas Base64 a imagen
        /// </summary>
        /// <param name="base64String">Cadena Base64</param>
        /// <returns>Image</returns>
        public static Image ParseBase64String(this string base64String)
        {
            /*
            * Referencia：
            * 1.http://www.dailycoding.com/Posts/convert_image_to_base64_string_and_base64_string_to_image.aspx
            */
            byte[] _imageBytes = Convert.FromBase64String(base64String);
            using(MemoryStream ms = new MemoryStream(_imageBytes, 0, _imageBytes.Length))
            {
                ms.Write(_imageBytes, 0, _imageBytes.Length);
                Image _image = Image.FromStream(ms, true);
                return _image;
            }
        }

        /// <summary>
        /// Convertir byte [] a imagen
        /// </summary>
        /// <param name="buffer">Secuencia de imagen binaria</param>
        /// <returns>Image</returns>
        public static Image ParseByteArray(this byte[] buffer)
        {
            using(MemoryStream ms = new MemoryStream(buffer))
            {
                Image _saveImage = Image.FromStream(ms);
                ms.Flush();
                return _saveImage;
            }
        }

        /// <summary>
        /// Convertir imagen a cadena Base64
        /// </summary>
        /// <param name="sourceImageFile">Archivo de imagen</param>
        /// <param name="format">ImageFormat</param>
        /// <returns> Base64 string </returns>
        public static string ToBase64String(this Image sourceImageFile, ImageFormat format)
        {
            /*
             * Referencia：
             * 1.http://www.dailycoding.com/Posts/convert_image_to_base64_string_and_base64_string_to_image.aspx
             */
            using(MemoryStream ms = new MemoryStream())
            {
                sourceImageFile.Save(ms, format);
                byte[] _imageBytes = ms.ToArray();
                string _base64String = Convert.ToBase64String(_imageBytes);
                return _base64String;
            }
        }

        /// <summary>
        /// Convierta imágenes de tipo .png, .bmp, .jpg a tipo de mapa de bits
        /// </summary>
        /// <param name="sourceImageFile">ruta de la imagen</param>
        /// <returns>Bitmap</returns>
        public static Bitmap ToBitmap(string sourceImageFile)
        {
            return (Bitmap)Bitmap.FromFile(sourceImageFile, false);
        }

        /// <summary>
        /// Convertir imagen a matriz de bytes
        /// </summary>
        /// <param name="sourceImageFile">Archivo de imagen</param>
        /// <param name="imageFormat">ImageFormat</param>
        /// <returns>Matriz BYTE</returns>
        public static byte[] ToBytes(this Image sourceImageFile, ImageFormat imageFormat)
        {
            byte[] _data = null;
            using(MemoryStream ms = new MemoryStream())
            {
                using(Bitmap bitmap = new Bitmap(sourceImageFile))
                {
                    bitmap.Save(ms, imageFormat);
                    ms.Position = 0;
                    _data = new byte[ms.Length];
                    ms.Read(_data, 0, Convert.ToInt32(ms.Length));
                    ms.Flush();
                }
            }
            return _data;
        }

        /// <summary>
        /// Convertir imagen a matriz de bytes
        /// </summary>
        /// <param name="sourceImageFile">Archivo de imagen</param>
        /// <returns>Matriz BYTE</returns>
        public static byte[] ToBytes(this Bitmap sourceImageFile)
        {
            return ToBytes(sourceImageFile, sourceImageFile.RawFormat);
        }

        private static Size CreateImageSize(int width, int height, Image img)
        {
            double _w = 0.0,
                   _h = 0.0,
                   _sw = Convert.ToDouble(img.Width),
                   _sh = Convert.ToDouble(img.Height),
                   _mw = Convert.ToDouble(width),
                   _mh = Convert.ToDouble(height);

            if(_sw < _mw && _sh < _mh)
            {
                _w = _sw;
                _h = _sh;
            }
            else if((_sw / _sh) > (_mw / _mh))
            {
                _w = width;
                _h = (_w * _sh) / _sw;
            }
            else
            {
                _h = height;
                _w = (_h * _sw) / _sh;
            }

            return new Size(Convert.ToInt32(_w), Convert.ToInt32(_h));
        }

        /// <summary>
        /// Recorta la imagen original proporcionalmente al tamaño de la imagen que deseas
        /// </summary>
        /// <param name="width">Ancho de la miniatura</param>
        /// <param name="height">Altura de la miniatura</param>
        /// <param name="img">Imagen original</param>
        /// <returns>Tamaño del área de cultivo</returns>
        private static Size CutRegion(int width, int height, Image img)
        {
            double _width = 0.0,
                   _height = 0.0;
            double _nw = (double)width,
                   _nh = (double)height,
                   _pw = (double)img.Width,
                   _ph = (double)img.Height;

            if(_nw / _nh > _pw / _ph)
            {
                _width = _pw;
                _height = _pw * _nh / _nw;
            }
            else if(_nw / _nh < _pw / _ph)
            {
                _width = _ph * _nw / _nh;
                _height = _ph;
            }
            else
            {
                _width = _pw;
                _height = _ph;
            }

            return new Size(Convert.ToInt32(_width), Convert.ToInt32(_height));
        }

        /// <summary>
        /// Usar al guardar JPG
        /// </summary>
        /// <param name="mimeType"> </param>
        /// <returns>Obtenga el ImageCodecInfo del mimeType especificado</returns>
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();

            foreach(ImageCodecInfo ici in CodecInfo)
            {
                if(ici.MimeType == mimeType) return ici;
            }

            return null;
        }

        /// <summary>
        /// Guardar en formato JPEG con soporte para opciones de calidad de compresión
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="fileName"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        private static bool KiSaveAsJPEG(string sourceFile, string fileName, int qty)
        {
            Bitmap _bmp = new Bitmap(sourceFile);

            try
            {
                EncoderParameter _p;
                EncoderParameters _ps;
                _ps = new EncoderParameters(1);
                _p = new EncoderParameter(Encoder.Quality, qty);
                _ps.Param[0] = _p;
                _bmp.Save(fileName, GetCodecInfo("image/jpeg"), _ps);
                _bmp.Dispose();
                return true;
            }
            catch
            {
                _bmp.Dispose();
                return false;
            }
        }

        [DllImport("msvcrt.dll")]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

        /// <summary>
        /// memcmp API
        /// </summary>
        /// <param name="b1">Conjunto de bytes 1</param>
        /// <param name="b2">Conjunto de bytes 2</param>
        /// <param name="count">The count.</param>
        /// <returns> Devuelve 0 si las dos matrices son iguales y un valor menor que 0 si la matriz 1 es menor que la matriz 2; 
        ///          devuelve un valor mayor que 0 si la matriz 1 es mayor que la matriz 2.
        /// </returns>
        [DllImport("msvcrt.dll")]
        private static extern IntPtr memcmp(byte[] b1, byte[] b2, IntPtr count);

        private static void SetWaterMarkImagePosition(Graphics sourceG, Image sourceImage, int sourceImageWidth, int sourceImageHight, SetWaterPosition position)
        {
            Size _sourceSize = CreateImageSize(sourceImageWidth, sourceImageHight, sourceImage);
            int _nx = 0,
                _ny = 0,
                _padding = 10;

            switch (position)
            {
                case SetWaterPosition.center:
                    _nx = (sourceImageWidth - _sourceSize.Width) / 2;
                    _ny = (sourceImageHight - _sourceSize.Height) / 2;
                    break;

                case SetWaterPosition.topLeft:
                    _nx = _padding;
                    _ny = _padding;
                    break;

                case SetWaterPosition.topRight:
                    _nx = (sourceImageWidth - _sourceSize.Width) - _padding;
                    _ny = _padding;
                    break;

                case SetWaterPosition.bottomLeft:
                    _nx = _padding;
                    _ny = (sourceImageHight - _sourceSize.Height) - _padding;
                    break;

                default:
                    _nx = (sourceImageWidth - _sourceSize.Width) - _padding;
                    _ny = (sourceImageHight - _sourceSize.Height) - _padding;
                    break;
            }

            sourceG.DrawImage(sourceImage, new Rectangle(_nx, _ny, _sourceSize.Width, _sourceSize.Height),
                              0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Establecer la calidad de la imagen de marca de agua
        /// </summary>
        /// <param name="sourceBmp">The source BMP.</param>
        /// <param name="sourceImageFile">The source image file.</param>
        /// <param name="sourceImageFormat">The source image format.</param>
        private static void SetWaterMarkImageQuality(Bitmap sourceBmp, string sourceImageFile, ImageFormat sourceImageFormat)
        {
            // El siguiente código establece la calidad de compresión al guardar una imagen.
            EncoderParameters _encoderParams = new EncoderParameters();
            long[] _quality = new long[1] { 100 };
            EncoderParameter _encoderParam = new EncoderParameter(Encoder.Quality, _quality);
            _encoderParams.Param[0] = _encoderParam;
            // Obtenga un objeto ImageCodecInfo que contenga información sobre el códec de imagen incorporado.
            ImageCodecInfo[] _arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo _jpegICI = null;

            for (int x = 0; x < _arrayICI.Length; x++)
            {
                if (_arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    _jpegICI = _arrayICI[x]; // Establecer codificación JPEG
                    break;
                }
            }

            if (_jpegICI != null)
            {
                sourceBmp.Save(sourceImageFile, _jpegICI, _encoderParams);
            }
            else
            {
                sourceBmp.Save(sourceImageFile, sourceImageFormat);
            }
        }

        private static void SetWaterMarkTextPosition(Graphics graphics, string text, Image _sourceImage, int _sourceImageWidth, int _sourceImageHight)
        {
            int[] _sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            Font _font = null;
            SizeF _crSize = new SizeF();

            // Use un tamaño de fuente diferente recorriendo esta matriz
            // Si su tamaño es menor que el ancho de la imagen, use esta fuente de tamaño.
            for (int i = 0; i < 7; i++)
            {
                // Establece la fuente, aquí es arial, negrita
                _font = new Font("arial", _sizes[i], FontStyle.Bold);
                _crSize = graphics.MeasureString(text, _font);

                if ((ushort)_crSize.Width < (ushort)_sourceImageWidth)
                    break;
            }

            // Debido a que la altura de la imagen puede no ser la misma, así se define
            // 5% de espacio reservado desde la parte inferior de la imagen
            int _yPixlesFromBottom = (int)(_sourceImageHight * .08);
            // Ahora use la altura de la cadena de información de copyright para determinar la coordenada y de la cadena de la imagen a dibujar
            float _yPosFromBottom = ((_sourceImageHight - _yPixlesFromBottom) - (_crSize.Height / 2));
            // Calcule la coordenada x
            float _xCenterOfImg = (_sourceImageWidth / 2);
            // Establecer el diseño del texto en centrado
            StringFormat _format = new StringFormat();
            _format.Alignment = StringAlignment.Center;
            // Set negro translúcido por Brush
            SolidBrush _semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            // Dibuja una cadena de copyright
            graphics.DrawString(text, // Texto de cadena de copyright
                                _font, //Font
                                _semiTransBrush2, // Brush
                                new PointF(_xCenterOfImg + 1, _yPosFromBottom + 1), // Ubicación
                                _format);

            // 设置成白色半透明
            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
            // 第二次绘制版权字符串来创建阴影效果
            // 记住移动文本的位置1像素
            graphics.DrawString(text,// 版权文本
                                _font, //字体
                                semiTransBrush, //Brush
                                new PointF(_xCenterOfImg, _yPosFromBottom), // 位置
                                _format);
        }


        #endregion Methods
    }
}
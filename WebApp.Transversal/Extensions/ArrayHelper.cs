namespace WebApp.Transversales.Extensions
{
    using System;
    using Operator;

    /// <summary>
    /// Clase auxiliar de matriz
    /// </summary>
    public static class ArrayHelper
    {
        #region Methods

        /// <summary>
        /// Agregar un nuevo elemento a la matriz
        /// <para>eg: CollectionAssert.AreEqual(new int[6] { 1, 2, 3, 4, 5, 6 }, ArrayHelper.Add(new int[5] { 1, 2, 3, 4, 5 }, 6));</para>
        /// </summary>
        /// <typeparam name="T">Genérico</typeparam>
        /// <param name="sourceArray">Matriz que necesita ser manipulada</param>
        /// <param name="item">Necesita agregar un elemento de matriz</param>
        /// <returns>Matriz</returns>
        public static T[] Add<T>(T[] sourceArray, T item)
        {
            ValidateOperator.Begin().NotNull(sourceArray, "Matriz que necesita ser manipulada").NotNull(item, "Necesita agregar un elemento de matriz");
            int _count = sourceArray.Length;
            Array.Resize<T>(ref sourceArray, _count + 1);
            sourceArray[_count] = item;
            return sourceArray;
        }

        /// <summary>
        /// Agregar una nueva matriz a la matriz；
        /// <para>
        /// eg: CollectionAssert.AreEqual(new int[7] { 1, 2, 3, 4, 5, 6, 7 },
        ///     ArrayHelper.AddRange(new int[5] { 1, 2, 3, 4, 5 }, new int[2] { 6, 7 }));
        /// </para>
        /// </summary>
        /// <typeparam name="T">Genérico</typeparam>
        /// <param name="sourceArray">Matriz que necesita ser manipulada</param>
        /// <param name="addArray">Se agregó la matriz</param>
        /// <returns>Matriz</returns>
        public static T[] AddRange<T>(T[] sourceArray, T[] addArray)
        {
            ValidateOperator.Begin().NotNull(sourceArray, "Matriz que necesita ser manipulada").NotNull(addArray, "Se agregó la matriz");
            int _count = sourceArray.Length;
            int _addCount = addArray.Length;
            Array.Resize<T>(ref sourceArray, _count + _addCount);
            addArray.CopyTo(sourceArray, _count);
            return sourceArray;
        }

        /// <summary>
        /// Matriz vacía
        /// <para>
        /// eg:
        /// int[] _test = new int[5] { 1, 2, 3, 4, 5 };
        /// _test.ClearAll();
        /// CollectionAssert.AreEqual(new int[5] { 0, 0, 0, 0, 0 }, _test);
        /// </para>
        /// </summary>
        /// <param name="sourceArray">Matriz</param>
        public static void ClearAll(Array sourceArray)
        {
            ValidateOperator.Begin().NotNull(sourceArray, "Matriz que necesita ser manipulada");
            Array.Clear(sourceArray, 0, sourceArray.Length);
        }

        /// <summary>
        /// Determine si los valores de la matriz son iguales
        /// <para> eg: Assert.IsTrue(ArrayHelper.CompletelyEqual(new int[5] { 1, 2, 3, 4, 5 }, new int[5] { 1, 2, 3, 4, 5 }));
        /// </para>
        /// </summary>
        /// <typeparam name="T">Genérico</typeparam>
        /// <param name="sourceArray">Array uno</param>
        /// <param name="compareArray">Array dos</param>
        /// <returns>¿Es igual?</returns>
        public static bool CompletelyEqual<T>(this T[] sourceArray, T[] compareArray)
        {
            ValidateOperator.Begin().NotNull(sourceArray, "Matriz que necesita ser manipulada").NotNull(compareArray, "Matriz que se compara");

            if(sourceArray == null || compareArray == null)
            {
                return false;
            }

            if(sourceArray.Length != compareArray.Length)
            {
                return false;
            }

            for(int i = 0; i < sourceArray.Length; i++)
            {
                if(!sourceArray[i].Equals(compareArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Copiar matriz
        /// <para>
        /// eg: CollectionAssert.AreEqual(new int[3] { 1, 2, 3 }, ArrayHelper.Copy(new int[5] { 1,
        ///     2, 3, 4, 5 }, 0, 3));
        /// </para>
        /// </summary>
        /// <typeparam name="T">Genérico</typeparam>
        /// <param name="sourceArray">Necesidad de manipular la matriz</param>
        /// <param name="startIndex">Copiar índice de inicio, comenzando desde cero</param>
        /// <param name="endIndex">Copiar índice final</param>
        /// <returns>Matriz</returns>
        public static T[] Copy<T>(T[] sourceArray, int startIndex, int endIndex)
        {
            ValidateOperator.Begin().NotNull(sourceArray, "Matriz que necesita ser manipulada")
            .CheckGreaterThan<int>(startIndex, "Copiar índice de inicio", 0, true)
            .CheckGreaterThan<int>(endIndex, "Copiar índice final", startIndex, false)
            .CheckLessThan<int>(endIndex, "Copiar índice final", sourceArray.Length, true);
            int _len = endIndex - startIndex;
            T[] _destination = new T[_len];
            Array.Copy(sourceArray, startIndex, _destination, 0, _len);
            return _destination;
        }

        /// <summary>
        /// Determine si la matriz está vacía o NULL
        /// <para>eg:Assert.IsTrue(ArrayHelper.IsEmpty(new int[0]));</para>
        /// </summary>
        /// <param name="data">Matriz</param>
        /// <returns>Si está vacío o NULL</returns>
        public static bool IsEmpty(this Array data)
        {
            if(data == null || data.Length == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Expande o reduce la matriz
        /// </summary>
        /// <typeparam name="T">Genérico</typeparam>
        /// <param name="array">Matriz</param>
        /// <param name="newSizes">Nuevo tamaño de matriz</param>
        public static T[] Resize<T>(this T[] array, int newSizes)
        {
            Array.Resize<T>(ref array, newSizes);
            return array;
        }
        #endregion Methods
    }
}
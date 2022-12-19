﻿using System.Numerics;

namespace MathLib.Matrices;

/// <summary>
/// Represents a matrix.
/// </summary>
/// <typeparam name="T">Matrix from this type.</typeparam>
public class Matrix<T> where T : INumber<T>
{
    /// <summary>
    /// Creates a matrix from a 2D array.
    /// </summary>
    /// <param name="matrixArray">2D array to create a matrix.</param>
    public Matrix(T[,] matrixArray)
    {
        MatrixArray = matrixArray;
    }

    /// <summary>
    /// Matrix array.
    /// </summary>
    public T[,] MatrixArray { get; }
    
    /// <summary>
    /// Adds two matrices.
    /// </summary>
    /// <param name="matrix1">First matrix.</param>
    /// <param name="matrix2">Second matrix.</param>
    /// <returns>New matrix added from the first and second.</returns>
    /// <exception cref="ArgumentException">Matrices must have the same size.</exception>
    public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
    {
        if (matrix1.MatrixArray.GetLength(0) != matrix2.MatrixArray.GetLength(0) ||
            matrix1.MatrixArray.GetLength(1) != matrix2.MatrixArray.GetLength(1))
        {
            throw new ArgumentException("Matrices must have the same size.");
        }

        var resultArr = new T[matrix1.MatrixArray.GetLength(0), matrix1.MatrixArray.GetLength(1)];

        for (var i = 0; i < matrix1.MatrixArray.GetLength(0); i++)
        {
            for (var j = 0; j < matrix1.MatrixArray.GetLength(1); j++)
            {
                resultArr[i, j] = (dynamic)matrix1.MatrixArray[i, j]! + matrix2.MatrixArray[i, j];
            }
        }

        return new Matrix<T>(resultArr);
    }
    
    /// <summary>
    /// Subtract one matrix from another.
    /// </summary>
    /// <param name="matrix1">First matrix.</param>
    /// <param name="matrix2">Second matrix.</param>
    /// <returns>New matrix by subtracting the second from the first.</returns>
    /// <exception cref="ArgumentException">Matrices must have the same size.</exception>
    public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
    {
        if (matrix1.MatrixArray.GetLength(0) != matrix2.MatrixArray.GetLength(0) ||
            matrix1.MatrixArray.GetLength(1) != matrix2.MatrixArray.GetLength(1))
        {
            throw new ArgumentException("Matrices must have the same size.");
        }

        var resultArr = new T[matrix1.MatrixArray.GetLength(0), matrix1.MatrixArray.GetLength(1)];

        for (var i = 0; i < matrix1.MatrixArray.GetLength(0); i++)
        {
            for (var j = 0; j < matrix1.MatrixArray.GetLength(1); j++)
            {
                resultArr[i, j] = (dynamic)matrix1.MatrixArray[i, j]! - matrix2.MatrixArray[i, j];
            }
        }

        return new Matrix<T>(resultArr);
    }
    
    // Multiply two matrices.
    public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
    {
        if (matrix1.MatrixArray.GetLength(1) != matrix2.MatrixArray.GetLength(0))
        {
            throw new ArgumentException("The number of columns of the first matrix must be equal to the number of rows of the second matrix.");
        }

        var resultArr = new T[matrix1.MatrixArray.GetLength(0), matrix2.MatrixArray.GetLength(1)];

        for (var i = 0; i < matrix1.MatrixArray.GetLength(0); i++)
        {
            for (var j = 0; j < matrix2.MatrixArray.GetLength(1); j++)
            {
                for (var k = 0; k < matrix1.MatrixArray.GetLength(1); k++)
                {
                    resultArr[i, j] = (dynamic)resultArr[i, j]! + matrix1.MatrixArray[i, k] * matrix2.MatrixArray[k, j];
                }
            }
        }

        return new Matrix<T>(resultArr);
    }
}
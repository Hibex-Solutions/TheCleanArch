// Copyright (c) E5R Development Team. All rights reserved.
// This file is a part of E5R CleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

namespace CleanArch.Core.Patterns.GuardClauses
{
    /// <summary>
    /// Implementa padrão "Guard Clauses" (cláusulas de guarda).
    /// </summary>
    /// <remarks>
    /// Saiba mais sobre o padrão em https://deviq.com/design-patterns/guard-clause
    /// </remarks>
    public static class Guard
    {
        /// <summary>
        /// Um argumento não pode ser nulo
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="paramInput">Valor de entrada</param>
        /// <param name="paramName">Nome do parâmetro</param>
        /// <returns>Retorna o próprio valor de entrada se tudo correr bem</returns>
        /// <exception cref="ArgumentNullException">Quando o valor de entrada é nulo</exception>
        public static T NotNullArgument<T>(T paramInput, string paramName)
            where T : class => paramInput ?? throw new ArgumentNullException(paramName);

        /// <summary>
        /// Um argumento enumerável não pode ser vazio
        /// </summary>
        /// <typeparam name="T">Tipo enumerável</typeparam>
        /// <param name="paramInput">Valor de entrada</param>
        /// <param name="paramName">Nome do parâmetro</param>
        /// <returns>Retorna o próprio valor de entrada se tudo correr bem</returns>
        /// <exception cref="ArgumentNullException">Quando o valor de entrada é nulo</exception>
        /// <exception cref="ArgumentOutOfRangeException">Quando o valor de entrada não é nulo mas está vazio</exception>
        public static T NotEmptyArgument<T>(T paramInput, string paramName)
            where T : IEnumerable => paramInput == null
                ? throw new ArgumentNullException(paramName)
                : !paramInput.GetEnumerator().MoveNext()
                ? throw new ArgumentOutOfRangeException(paramName)
                : paramInput;
    }
}
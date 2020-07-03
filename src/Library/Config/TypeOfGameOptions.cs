using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Este enumerado es una abstraccion de los tipos de juego.
    /// Agregado por SRP. La única razón de cambio es modificar los tipos de juego.
    /// </summary>
    public enum TypeOfGameOptions
        {
            IncompletTextAndAnswerText,
            IncompletTextAndFreeAnswer,
            ImageAndAnswerText,
            ImageAndFreeAnswer
        }
}

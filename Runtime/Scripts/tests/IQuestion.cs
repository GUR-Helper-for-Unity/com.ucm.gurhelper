namespace GURHelper
{
    public interface IQuestion
    {
        string enunciado { get; }
        int? numero { get; }

        /// <summary>
        /// M�todo en el que una pregunta del test devolver� la respuesta del usuario. Se devolver� toda la informaci�n asociada a la pregunta
        /// </summary>
        public string Interpret();
    }
}


namespace GURHelper
{
    public interface IQuestion
    {
        string enunciado { get; }
        int? numero { get; }

        /// <summary>
        /// Método en el que una pregunta del test devolverá la respuesta del usuario. Se devolverá toda la información asociada a la pregunta
        /// </summary>
        public string Interpret();
    }
}


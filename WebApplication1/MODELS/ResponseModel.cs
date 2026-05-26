using WebApplication1.Migrations;

namespace WebApplication1.MODELS
{
    public class ResponseModel<T>
    {
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public T? Dados { get; set; }

    }
}

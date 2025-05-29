namespace AppAngular.Server.Utils
{
    public class Constantes
    {
        public static int CODIGO_EXITO = 200;
        public static int CODIGO_NO_DATA = 400;
        public static int CODIGO_ERROR = 500;

        public static string MENSAJE_OK = "ACCION REALIZADA CORRECTAMENTE";
        public static string MENSAJE_NO_DATA = "SIN DATOS PARA RETORNAR";
        public static string MENSAJE_ERROR = "OCURRIO UN ERROR {0}";

        public static string getMensaje(string detalleError)
        {
            return string.Format(MENSAJE_ERROR, detalleError);
        }
    }
}

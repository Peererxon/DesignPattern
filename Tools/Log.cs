namespace Tools;
public class Log
{
    // Patron singleton, una sola instancia para toda la app
    private static Log _instance = null;
    private string _path;
    private static object _obj = new object();
    public static Log GetInstance(string path)
    {
        // En .net podemos trabajar con distintos hilos
        // este lock lo que hace es decirle a .net mientras evaluas entra propiedad otro hilo esperara para usarla
        //por lo que con esto aseguramos que solo se cree una sola instancia, con 2 hilos sin esto podia ocurrir que al ambos hilos entrar aqui crearian 2 intancias de objeto
        lock (_obj)
        {
            // Esto practicamente se resume a: si la instancia es nula, creala
            // si ya existe retornala
            if (_instance == null)
            {
                _instance = new Log(path);
            }
        }


        return _instance;
    }
    
    // con el constructor privado no puede crearse una instancia de esta clase sino dentro de la misma clase
    private Log(string path)
    {
        _path = path;
    }

    public void Save(string message)
    {
        File.AppendAllText(_path, message + Environment.NewLine);

    }
}
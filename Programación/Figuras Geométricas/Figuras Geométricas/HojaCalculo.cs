using System.ComponentModel;

public class HojaCalculo
{
    //public static String[,] datos(string nameFile)
    public static List<string> datos(string nameFile)
    {
        //String? line;
        //List<List<String>> datosLista;
        //String[,] datos;

        //StreamReader? myfile = new(nameFile, System.Text.Encoding.Default);
        //if (myfile == null)
        //    throw new IOException("No se pudo leer el fichero " + nameFile);

        //datosLista = new List<List<String>>();
        //while ((line = myfile.ReadLine()) != null)
        //{
        //    if (line != "")
        //    {
        //        datosLista.Add(line.Split(';').ToList());
        //    }
        //}
        //myfile.Close();
        //datos = new String[datosLista.Count, datosLista[0].Count];
        //for (int i = 0; i < datosLista.Count; i++)
        //    for (int j = 0; j < datosLista[i].Count; j++)
        //        datos[i, j] = datosLista[i][j];

        List<string> datos = new List<string>();

        List<string> listA = File.ReadAllLines(nameFile).ToList();
        string[] aux = new string[6];
        for (int i = 0; i < listA.Count; i++)
        {
            aux = (listA[i].Split(';'));
                for (int j = 0; j < aux.Length; j++)
                    datos.Add(aux[j]);
        }

        return datos;
    }
}
namespace Sorteo_Nombre
{
    public class Sorteo : AbstractaSorteo
    {
        private static int numCandidatos = 5;

        public Sorteo() : base(numCandidatos)
        {

        }

        public override void Incluir(string nombre)
        {
            
        }

        public override void Incluir(string[] nombres)
        {
            
        }

        public override string[] Seleccionar(int cuantos)
        {
            string[] result = null;

            
            return result;
        }

        public override string Seleccionar()
        {
            string result = "";

            return result;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
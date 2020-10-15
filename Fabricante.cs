using System;
using System.Threading;

namespace fabricantevendedor
{
    public class Fabricante //@ionene
    {
        private Almacen _a;
        private Thread _t;
        private Random _rnd = new Random();
        private int _ms;
        private int _capacidad;
        public Fabricante(Almacen a, int ms, int capacidad)
        {
            this._a = a;
            this._ms = ms;
            this._capacidad = capacidad;
        }

        public void Fabrica()
        {
            this._t = new Thread(() => this._Accion());
            this._t.Start();
        }

        public void Termina()
        {
            _t.Join();
        }

        private void _Accion()
        {
            int ms;
            for (int i = 0; i < 10; i++)
            {
                ms = _rnd.Next(1000, 2000);
                Thread.Sleep(ms);
                _a.Guardar();
            }
        }
    }

}
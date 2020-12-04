using System.Collections.Generic;
using System.ComponentModel;

namespace SuperheroesTriggers
{
    class Superheroe : INotifyPropertyChanged
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }

        private string _imagen;

        public string Imagen
        {
            get { return _imagen; }
            set
            {
                _imagen = value;
                NotifyPropertyChanged("Imagen");
            }
        }

        private bool _vengador;

        public bool Vengador
        {
            get { return _vengador; }
            set
            {
                _vengador = value;
                NotifyPropertyChanged("Vengador");
            }
        }

        private bool _xmen;

        public bool Xmen
        {
            get { return _xmen; }
            set
            {
                _xmen = value;
                NotifyPropertyChanged("Xmen");
            }
        }

        private bool _heroe;

        public bool Heroe
        {
            get { return _heroe; }
            set
            {
                _heroe = value;
                NotifyPropertyChanged("Heroe");
            }
        }


        private bool _villano;

        public bool Villano
        {
            get { return _villano; }
            set
            {
                _villano = value;
                NotifyPropertyChanged("Villano");

                // Controlamos que los CheckBox no estén marcados
                if (value)
                {
                    Vengador = false;
                    Xmen = false;
                }
            }
        }


        public Superheroe()
        {
        }

        public Superheroe(string nombre, string imagen, bool vengador, bool xmen, bool heroe, bool villano)
        {
            Nombre = nombre;
            Imagen = imagen;
            Vengador = vengador;
            Xmen = xmen;
            Heroe = heroe;
            Villano = villano;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<Superheroe> GetSamples()
        {
            List<Superheroe> ejemplos = new List<Superheroe>();

            Superheroe ironman = new Superheroe("Ironman", @"https://sm.ign.com/ign_latam/screenshot/default/ybbpqktez5whedr0-1592031889_31aa.jpg", true, false, true, false);
            Superheroe kingpin = new Superheroe("Kingpin", @"https://www.comicbasics.com/wp-content/uploads/2017/09/Kingpin.jpg", false, false, false, true);
            Superheroe spiderman = new Superheroe("Spiderman", @"https://wipy.tv/wp-content/uploads/2019/08/destino-de-%E2%80%98Spider-Man%E2%80%99-en-los-Comics.jpg", true, true, true, false);

            ejemplos.Add(ironman);
            ejemplos.Add(kingpin);
            ejemplos.Add(spiderman);

            return ejemplos;
        }
    }


}

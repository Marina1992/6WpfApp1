using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    class WeatherControl : DependencyObject
    {

        
        

        public static readonly DependencyProperty TempProperty;  //температура 


        private string windDirection; //направление ветра


        private int windSpeed; // скорость ветра 

        


        public string WindDirection


        
        {
            get => windDirection;
            set => windDirection = value;

        }


        public int WindSpeed



        {
            get => windSpeed;
            set => windSpeed = value;

        }




        public int Temp


        {
            get => (int)GetValue(TempProperty);

           
            set => SetValue(TempProperty, value);


            
        }

        public WeatherControl(string windDirection, int C, int V)
        {
            this.WindDirection = windDirection;
            this.Temp = C;
            this.WindSpeed = V;

        }

        enum Rainfall // наличие осадков
        {
            Sunny,
            Cloudy,
            Rain,
            Snow
        }
        

        static WeatherControl()

        {
            TempProperty = DependencyProperty.Register(

              

                nameof(Temp),

               

                typeof(int),

               

                typeof(WeatherControl),

                   
                new FrameworkPropertyMetadata(
                0,
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                       null,
                        new CoerceValueCallback(CoerceTemp)),
                        new ValidateValueCallback(ValidateTemp));


        }

        private static bool ValidateTemp(object value)
        {
          
            int v = (int)value;

            if (v >= -50 && v <= 50)
                return true;

            else

                return false;
        }

        
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            

            int v = (int)baseValue;

            if (v >= -50)
                return v;

            else

                return 0;

        }

        public string Print()

        {
            return $"Cводка погоды: {Temp} С, направление ветра  {WindDirection} , скорость вкетра {WindSpeed}  ";

        }

        
    }
}


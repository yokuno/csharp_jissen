using System;

namespace _172 {
    class Program {
        static void Main(string[] args) {
            var mileConverter = new MileConverter();
            var killoMeterConverter = new KilloMeterConverter();
            Console.WriteLine("3メール={0}{1}", mileConverter.ToMeter(3000), mileConverter.UnitName);
            Console.WriteLine("3メートル={0}{1}", killoMeterConverter.ToMeter(3000), killoMeterConverter.UnitName);


        }
    }


    public abstract class ConverterBase {
        protected abstract double Ratio { get; }

        public abstract string UnitName { get; }

        public double FromMeter(double meter) {
            return meter / Ratio;
        }

        public double ToMeter(double feet) {
            return feet * Ratio;
        }
    }

    public class MeterConverter : ConverterBase {
        protected override double Ratio { get { return 1; } }
        public override string UnitName { get { return "メートル"; } }
    }

    public class MileConverter : ConverterBase {
        protected override double Ratio { get { return 0.000621371; } }
        public override string UnitName { get { return "マイル"; } }
    }


    public class KilloMeterConverter : ConverterBase {
        protected override double Ratio { get { return 0.001; } }
        public override string UnitName { get { return "キロメートル"; } }
    }
}

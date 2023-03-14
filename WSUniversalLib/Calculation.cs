namespace WSUniversalLib
{
    public class Calculation
    {
        public static long GetQuantityForProduct(int productType, int materialType, 
                                         int count, float width, float length)
        {
            if (count <= 0 || width <= 0 || length <= 0) return -1;

            double coefficient;
            switch (productType)
            {
                case 1:
                    coefficient = 1.1;
                    break;
                case 2:
                    coefficient = 2.5;
                    break;
                case 3:
                    coefficient = 8.43;
                    break;
                default:
                    return -1;
            }

            double percentage;
            switch (materialType)
            {
                case 1:
                    percentage = 0.003;
                    break;
                case 2:
                    percentage = 0.0012;
                    break;
                default:
                    return -1;
            }

            double required = (width * length) * count * coefficient / (1 - percentage);
            if (long.MaxValue < required) return -1;
            return (long)Math.Ceiling(required);
        }
    }
}
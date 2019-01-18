using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterpolation
{
    public class BasicFunction
    {
        public float[] xTable;
        public float[] yTable;
        public float step, max;
        public int size;               
        public static int Amp;
        public static int f;

        public BasicFunction(int amp, int fr, float max, float step)
        {
            Amp = amp;
            f = fr;
            this.step = 0.1f;
            this.max = max;

            size = 1000;
            xTable = new float[size];
            yTable = new float[size];

        }

        public void BuildBasicFunction()
        {
            float j = 0;
            for (int i = 0; i < size; i++, j += step)
            {
                xTable[i] = j;
                yTable[i] = Func(j);
            }
        }

        public static float Func(float x, float a = 3, float b = 6, float c = 10, float d = 15)
        {
            //var y = Amp * Math.Sin(2 * Math.PI * f * x);
            a = f * a * 0.4f;
            b = f * b * 0.4f;
            c = f * c * 0.4f;
            d = f * d * 0.4f;

            float y = 0;
            if (x < a)
            {
                y = 0;
            }
            else if (x >= a && x < b)
            {
                y = (x - a) / (b - a);
            }
            else if (x > b && x <= c)
            {
                y = 1;
            }
            else if (x > c && x <= d)
            {
                y = (d - x) / (d - c);
            }
            else if (x > d)
            {
                y = 0;
            }
            return y * Amp;
        }

        public static float calcSize(int freq)
        {
            float s = 0;
            s = (freq >= 25) ? ((freq >= 100) ? (freq >= 1000 ? (freq >= 10000 ? 0.0001f : 0.001f) : 0.01f) : 0.1f) : 1;
            return s;
        }

        public static float calcStep(int freq)
        {
            return 0.1f / freq;
        }
    }
}

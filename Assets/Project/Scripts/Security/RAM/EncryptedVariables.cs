using System;
using System.Text;

namespace Project
{
    [Serializable]
    public struct pint
    {
        #region Variables
        public int value, offset;
        #endregion

        #region Methods
        public pint(int value = 0)
        {
            offset = Environment.TickCount + 101;
            this.value = value + offset;
        }

        public pint(string value = "0")
        {
            offset = Environment.TickCount + 101;
            this.value = int.Parse(value) + offset;
        }

        private int Get() => value - offset;

        public override string ToString() => Get().ToString();
        public override bool Equals(object obj) => Get().Equals(obj);
        public override int GetHashCode() => Get().GetHashCode();
        #endregion

        #region Operators
        public static implicit operator pint(int value) => new pint(value);
        public static implicit operator int(pint value) => value.Get();
        public static implicit operator pfloat(pint value) => value.Get();
        public static implicit operator float(pint value) => value.Get();

        public static bool operator ==(pint a, pint b) => a.Get() == b.Get();
        public static bool operator !=(pint a, pint b) => a.Get() != b.Get();

        public static bool operator >(pint a, pint b) => a.Get() > b.Get();
        public static bool operator <(pint a, pint b) => a.Get() < b.Get();

        public static bool operator >=(pint a, pint b) => a.Get() >= b.Get();
        public static bool operator <=(pint a, pint b) => a.Get() <= b.Get();

        public static pint operator +(pint a, pint b) => new pint(a.Get() + b.Get());
        public static int operator +(pint a, int b) => a.Get() + b;
        public static int operator +(int a, pint b) => a + b.Get();

        public static pint operator -(pint a, pint b) => new pint(a.Get() - b.Get());
        public static int operator -(pint a, int b) => a.Get() - b;
        public static int operator -(int a, pint b) => a - b.Get();
        public static pint operator -(pint value) => new pint(-value.Get());

        public static pint operator *(pint a, pint b) => new pint(a.Get() * b.Get());
        public static int operator *(pint a, int b) => a.Get() * b;
        public static int operator *(int a, pint b) => a * b.Get();

        public static pint operator /(pint a, pint b) => new pint(a.Get() / b.Get());
        public static int operator /(pint a, int b) => a.Get() / b;
        public static int operator /(int a, pint b) => a / b.Get();

        public static pint operator ++(pint value) => value + 1;
        public static pint operator --(pint value) => value - 1;

        public static pint operator ^(pint a, pint b) => a.Get() ^ b.Get();
        public static pint operator ^(pint a, byte b) => a.Get() ^ b;
        #endregion
    }

    [Serializable]
    public struct pfloat
    {
        #region Variables
        public float value;
        public int offset;
        #endregion

        #region Methods
        public pfloat(float value = 0f)
        {
            offset = Environment.TickCount % 100;
            this.value = value + offset;
        }
        
        private float Get() => value - offset;
        
        public override string ToString() => Get().ToString();
        public override bool Equals(object obj) => Get().Equals(obj);
        public override int GetHashCode() => Get().GetHashCode();
        #endregion

        #region Operators
        public static implicit operator pfloat(float value) => new pfloat(value);
        public static implicit operator float(pfloat value) => value.Get();
        public static implicit operator pint(pfloat value) => (int)value.Get();
        public static implicit operator int(pfloat value) => (int)value.Get();

        public static bool operator ==(pfloat a, pfloat b) => a.Get() == b.Get();
        public static bool operator !=(pfloat a, pfloat b) => a.Get() != b.Get();

        public static bool operator >(pfloat a, pfloat b) => a.Get() > b.Get();
        public static bool operator <(pfloat a, pfloat b) => a.Get() < b.Get();

        public static bool operator >=(pfloat a, pfloat b) => a.Get() >= b.Get();
        public static bool operator <=(pfloat a, pfloat b) => a.Get() <= b.Get();

        public static pfloat operator +(pfloat a, pfloat b) => new pfloat(a.Get() + b.Get());
        public static float operator +(pfloat a, float b) => a.Get() + b;
        public static float operator +(float a, pfloat b) => a + b.Get();

        public static pfloat operator -(pfloat a, pfloat b) => new pfloat(a.Get() - b.Get());
        public static float operator -(pfloat a, float b) => a.Get() - b;
        public static float operator -(float a, pfloat b) => a - b.Get();
        public static pfloat operator -(pfloat value) => new pfloat(-value.Get());

        public static pfloat operator *(pfloat a, pfloat b) => new pfloat(a.Get() * b.Get());
        public static float operator *(pfloat a, float b) => a.Get() * b;
        public static float operator *(float a, pfloat b) => a * b.Get();

        public static pfloat operator /(pfloat a, pfloat b) => new pfloat(a.Get() / b.Get());
        public static float operator /(pfloat a, float b) => a.Get() / b;
        public static float operator /(float a, pfloat b) => a / b.Get();

        public static pfloat operator ++(pfloat value) => value + 1f;
        public static pfloat operator --(pfloat value) => value - 1f;
        #endregion
    }

    [Serializable]
    public struct pstring
    {
        #region Variables
        public byte[] value;
        public byte key;
        #endregion

        #region Methods
        public pstring(string value = "")
        {
            key = (byte)(Environment.TickCount % 255);
            byte[] valueBytes = Encoding.Default.GetBytes(value);

            for (int i = 0; i < valueBytes.Length; i++)
                valueBytes[i] ^= key;

            this.value = valueBytes;
        }

        private string Get()
        {
            byte[] valueBytes = new byte[value.Length];

            for (int i = 0; i < valueBytes.Length; i++)
                valueBytes[i] = (byte)(value[i] ^ key);

            return Encoding.Default.GetString(valueBytes);
        }

        public override string ToString() => Get();
        public override bool Equals(object obj) => Get().Equals(obj);
        public override int GetHashCode() => Get().GetHashCode();
        #endregion

        #region Operators
        public static implicit operator pstring(string value) => new pstring(value);
        public static implicit operator string(pstring value) => value.Get();

        public static bool operator ==(pstring a, pstring b) => a.Get() == b.Get();
        public static bool operator !=(pstring a, pstring b) => a.Get() != b.Get();
        #endregion
    }
}

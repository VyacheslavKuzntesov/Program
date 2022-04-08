using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_23_03
{
#if AnonimDelegate
    public delegate double AnonimDelegateDouble(double x, double y);
    public delegate void AnonimDelegateInt(int n);
    public delegate void AnonimDelegateVoid();

    class Dispatcher
    {
        public event AnonimDelegateDouble eventDouble;
        public event AnonimDelegateInt eventVoid;

        public double OnEventDouble(double x, double y)
        {
            if (eventDouble != null)
                return eventDouble(x, y);
            throw new NotImplementedException();
        }

        public void OnEventVoid(int n = 0)
        {
            if (eventVoid != null)
                eventVoid(n);

        }
    } 
#endif

#if lyamda
    public delegate double AnonimDelegateDouble(double x, double y);
    public delegate void AnonimDelegateInt(int n);
    public delegate void AnonimDelegateVoid();

    class Dispatcher
    {
        public event AnonimDelegateDouble eventDouble;
        public event AnonimDelegateInt eventVoid;

        public double OnEventDouble(double x, double y)
        {
            if (eventDouble != null)
                return eventDouble(x, y);
            throw new NotImplementedException();
        }

        public void OnEventVoid(int n = 0)
        {
            if (eventVoid != null)
                eventVoid(n);

        }
    } 
#endif

    public delegate double AnonimDelegateDouble(double x, double y);
    public delegate void AnonimDelegateInt(int n);
    public delegate void AnonimDelegateVoid();

    class Dispatcher
    {
        public event AnonimDelegateDouble eventDouble;
        public event AnonimDelegateInt eventVoid;

        public double OnEventDouble(double x, double y)
        {
            if (eventDouble != null)
                return eventDouble(x, y);
            throw new NotImplementedException();
        }

        public void OnEventVoid(int n = 0)
        {
            if (eventVoid != null)
                eventVoid(n);

        }
    }
}

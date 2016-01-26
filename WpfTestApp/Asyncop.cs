using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfTestApp
{
    class Asyncop
    {
        public static async Task returnString(string meineBruder, CancellationToken token = new CancellationToken())
        {
            await Task.Delay(1200, token).ConfigureAwait(false);

            meineBruder = "few";
            Console.WriteLine(meineBruder);
        }
    }
}

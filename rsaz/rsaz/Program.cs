using System;
using System.Numerics;
using System.Threading.Tasks;

namespace rsaz
{
    class Program
    {
        public static void Txt()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Show n, fi(n), e, public key, d");
            Console.WriteLine("2. Encrypt");
            Console.WriteLine("3. Decrypt");
            Console.WriteLine("9. exit");
        }


        static void Main(string[] args)
        {
            RSA rsa = new RSA();

            Console.WriteLine("Iveskite q: ");
            int q = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iveskite p: ");
            int p = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter msg: ");
            String msg = Console.ReadLine();

            BigInteger n = rsa.getN(q, p);
            BigInteger Fin = rsa.getFi(q, p);
            BigInteger e = rsa.getPrime(rsa.rnd, Fin);
            BigInteger d = rsa.getD(e, Fin);

            Txt();
            int option = Convert.ToInt32(Console.ReadLine());

            while (option!=9)
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("N: " + n);
                        Console.WriteLine("Fi(N): " + Fin);
                        Console.WriteLine("e: " + e);
                        Console.WriteLine("d: " + d);
                        Console.WriteLine("public key: (" + n + ", " + e + ")");
                        break;
                    case 2:
                        Console.WriteLine(rsa.getEncriptedText(msg));
                        break;
                    case 3:
                        Console.WriteLine(rsa.getDecryptedText(rsa.getEncriptedText(msg)));
                        break;
                    default:
                        break;
                }
                Txt();
                option = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("n: " + n);
            Console.WriteLine("Fi(N): "+ Fin);
            Console.WriteLine("e: "+ e);
            Console.WriteLine("-------");
            Console.WriteLine("Public key: (" + n + " " + e + ")");
            Console.WriteLine("d: " + d);

            Console.WriteLine(rsa.getEncriptedText(msg));

            Console.WriteLine(rsa.getDecryptedText(rsa.getEncriptedText(msg)));


/*            Console.WriteLine(rsa.getEncriptedText("labas"));

            Console.WriteLine(rsa.getDecryptedText(rsa.getEncriptedText("labas")));*/
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DesafioProjetoHospedagem.Models
{
    public class Menu
    {
        List<Pessoa> listaHospedes = new List<Pessoa>();
        List<Suite> listaSuites = new List<Suite>();

        public void MenuPrincipal()
        {
            int opc = 0;

            System.Console.WriteLine("Administração de suites\n");
            System.Console.WriteLine(
                "1- Cadastrar hóspede\n" +
                "2- Cadastrar suite\n" +
                "3- Registrar reserva\n" +
                "4- Listar hóspedes\n" +
                "5- Listar suites\n" +
                "- Sair\n"
            );

            opc = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (opc)
            {
                case 1:
                    listaHospedes.Add(RegistrarHospede());
                    break;
                case 2:
                    listaSuites.Add(RegistrarSuite());
                    break;
                case 3:
                    RegistrarReserva();
                    break;
                case 4:
                    ListarHospedes();
                    break;
                case 5:
                    ListarSuites();
                    break;
                default:
                    break;
            }

            QualquerBotao();
        }

        public Pessoa RegistrarHospede()
        {
            Pessoa pessoa = new Pessoa();

            System.Console.WriteLine("Cadastro de hóspede\n");

            System.Console.Write("Primeiro nome: ");
            pessoa.Nome = Console.ReadLine();

            System.Console.Write("Último nome: ");
            pessoa.Sobrenome = Console.ReadLine();

            return pessoa;
        }

        public Suite RegistrarSuite()
        {
            Suite suite = new Suite();

            System.Console.WriteLine("Cadastro de suite\n");

            System.Console.Write("Nome da suite: ");
            suite.TipoSuite = Console.ReadLine();

            System.Console.Write("Capacidade: ");
            suite.Capacidade = Convert.ToInt32(Console.ReadLine());

            System.Console.Write("Valor da diaria: ");
            suite.ValorDiaria = Convert.ToInt32(Console.ReadLine());

            return suite;
        }

        public void ListarHospedes()
        {
            System.Console.WriteLine("Lista de hóspedes\n");

            if (listaHospedes.Count == 0)
            {
                System.Console.WriteLine("Não há hóspedes cadastrados.");
            }
            else
            {
                foreach (Pessoa hospede in listaHospedes)
                {
                    System.Console.WriteLine(hospede.NomeCompleto);
                }
            }
        }

        public void ListarSuites()
        {
            System.Console.WriteLine("Lista de suites\n");
            int suiteIndex = 1;

            if (listaSuites.Count == 0)
            {
                System.Console.WriteLine("Não há suites cadastradas.");
            }
            else
            {
                foreach (Suite suite in listaSuites)
                {
                    System.Console.WriteLine(
                        $"Codigo: {suiteIndex}\n" +
                        $"Suite: {suite.TipoSuite}\n" +
                        $"Capacidade: {suite.Capacidade}\n" +
                        $"Valor diaria: {suite.ValorDiaria}\n"
                    );
                    suiteIndex++;
                }
            }
        }

        public void RegistrarReserva()
        {
            Suite suite = new Suite();
            int diasReservados = 0;

            System.Console.WriteLine("Reserva de suite\n");

            if (listaSuites.Count == 0)
            {
                System.Console.WriteLine("Não há suites cadastradas.");
            }
            else if (listaHospedes.Count == 0)
            {
                System.Console.WriteLine("Não há hóspedes cadastrados.");
            }
            else
            {
                System.Console.Write("Dias reservados: ");
                diasReservados = Convert.ToInt32(Console.ReadLine());

                Reserva reserva = new Reserva(diasReservados);

                ListarSuites();

                System.Console.WriteLine($"Quantidade hóspedes: {listaHospedes.Count}");
                System.Console.Write("Selecione a suite: ");
                int suiteIndex = Convert.ToInt32(Console.ReadLine());

                suite = listaSuites.ElementAt<Suite>(suiteIndex - 1);

                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(listaHospedes);
                System.Console.WriteLine($"Quantidade de hóspede: {reserva.ObterQuantidadeHospedes()}\n");

                foreach (Pessoa hospede in listaHospedes)
                {
                    System.Console.WriteLine($"Hóspede: {hospede.NomeCompleto}");
                }

                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            }
        }

        public void QualquerBotao()
        {
            System.Console.WriteLine("Pressione qualquer botão para continuar");
            Console.ReadLine();
        }
    }
}
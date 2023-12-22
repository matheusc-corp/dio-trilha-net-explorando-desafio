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
        Pessoa pessoa = new Pessoa();
        Suite suite = new Suite();

        public void MenuPrincipal()
        {
            int opc = 0;

            // Console.Clear();

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
            // Console.Clear();

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
            System.Console.WriteLine("Cadastro de hóspede\n");

            System.Console.Write("Primeiro nome: ");
            pessoa.Nome = Console.ReadLine();

            System.Console.Write("Último nome: ");
            pessoa.Sobrenome = Console.ReadLine();

            return pessoa;
        }

        public Suite RegistrarSuite()
        {
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

            if (listaSuites.Count == 0)
            {
                System.Console.WriteLine("Não há suites cadastradas.");
            }
            else
            {
                foreach (Suite suite in listaSuites)
                {
                    System.Console.WriteLine(
                        $"Suite: {suite.TipoSuite}\n" +
                        $"Capacidade: {suite.Capacidade}\n" +
                        $"Valor diaria: {suite.ValorDiaria}\n"
                    );
                }
            }
        }

        public void RegistrarReserva()
        {
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

                System.Console.WriteLine($"Quantidade de hóspede: {listaHospedes.Count}");

                foreach (Pessoa hospede in listaHospedes)
                {
                    System.Console.WriteLine($"Hóspede: {hospede.NomeCompleto}");
                }

                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(listaHospedes);


                // Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                // Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            }

        }

        public void QualquerBotao()
        {
            System.Console.WriteLine("Pressione qualquer botão para continuar");
            Console.ReadLine();
        }
    }
}
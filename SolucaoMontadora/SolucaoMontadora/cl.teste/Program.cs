using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.BO;
using Negocio.Model;
using System.Collections;




namespace cl.teste
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurarJanela();
            Menu();


        }
        static void ConfigurarJanela()
        {
            Console.Title = "Cadastro de Clientes";
            Console.BufferHeight = 40;
            Console.BufferWidth = 100;
            Console.SetWindowSize(100, 40);
        }
        static void Menu()
        {
            Console.WriteLine("\n********** TESTE DE BACK END **********\n");
            Console.Write(" [ C ]- Cliente [2]- Fornecedo  | 3- Montador |4- Veiculo \n");

            OpcaoSelecionada();

        }
        static void OpcaoSelecionada()
        {
            ConsoleKeyInfo opcao = new ConsoleKeyInfo();
            opcao = Console.ReadKey();
            Console.Clear();
            if (opcao.Key == ConsoleKey.C)
            {
                //CadastrarCliente();

            }
            if (opcao.Key == ConsoleKey.F)
            {
                CadastrarFornecedor();
            }


        }
        //static void CadastrarCliente()
        //{
        //    Cliente objCliente = new Cliente();
        //    ClienteDAO cDAO = new ClienteDAO();
        //    Console.WriteLine("\n********** CADASTRO DE CLIENTE **********\n");

        //    Console.WriteLine("\nNome do Cliente:");
        //    string nome = Console.ReadLine();
        //    Console.WriteLine("\nCPF do Cliente:");
        //    string cpf = Console.ReadLine();
        //    Console.WriteLine("\nEndereço do Cliente:");
        //    string endereco = Console.ReadLine();
        //    Console.WriteLine("\nData de Nascimento do Cliente:");
        //    string dtNasciemnto = Console.ReadLine();
        //    Console.WriteLine("\nSexo do Cliente:");
        //    string Sexo = Console.ReadLine();
        //    Console.WriteLine("\nRG do Cliente:");
        //    string rg = Console.ReadLine();
        //    Console.WriteLine("\nOrgão Expedidor :");
        //    string orgaoExpedidor = Console.ReadLine();
        //    Console.WriteLine("\nNumero :");
        //    string numero = Console.ReadLine();
        //    Console.WriteLine("\nCidade do Cliente:");
        //    string cidade =Console.ReadLine();

        //    objCliente.Nome = nome;
        //    objCliente.Cpf = cpf;
        //    objCliente.Endereco = endereco;
        //    objCliente.DataNascimento = Convert.ToDateTime(dtNasciemnto);
        //    objCliente._Sexo =(Sexo)Enum.Parse(typeof(Sexo),Sexo);
        //    objCliente.Rg = rg;
        //    objCliente.OrgaoExpedidor = orgaoExpedidor;
        //    objCliente.Numero = numero;
        //    //objCliente.Cidade = Convert.to;

        //    cDAO.Inserir(objCliente);


        //}
        static void CadastrarFornecedor()
        {
            Console.WriteLine("\n********** CADASTRO DE FORNECEDOR **********\n");

            Fornecedor objFornecedor = new Fornecedor();
            FornecedorBO fBO = new FornecedorBO();
            Console.WriteLine("\nNome do Fornecedor:");
            string nome = Console.ReadLine();
            Console.WriteLine("\nCPF do Fornedor:");
            string cpf = Console.ReadLine();
            Console.WriteLine("\nEndereço do Fornedor:");
            string endereco = Console.ReadLine();

            objFornecedor.Nome = nome;
            objFornecedor.Cpf = cpf;
            objFornecedor.Endereco = endereco;
            try
            {
                fBO.Gravar(objFornecedor);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }




    }
}

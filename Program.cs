﻿using System;

namespace APP.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        //AtualizarSerie();
                        break;
                    case "4":
                        //ExcluirSerie();
                        break;
                    case "5":
                        //VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por utilizar nossos Serviços.");
            Console.ReadLine();
           
        }

        private static void ListarSeries()
                {
                    Console.WriteLine("Listar Séries");

                    var lista = repositorio.Lista();
                    if (lista.Count == 0)
                    {
                        Console.WriteLine("Nenhuma Série Cadastrada");
                        return;
                    }
                    foreach (var serie in lista)
                    {
                        Console.WriteLine("#ID {0}: - {1}", serie.retonraId(), serie.retornaTitulo());
                    }
                }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);        
        }

        private static string ObterOpcaoUsuario()
        {
             Console.WriteLine();
             Console.WriteLine("App Séries a seu dispor!!!");
             Console.WriteLine("Informe a opção desejada: ");

             Console.WriteLine("1- Listar Séries");
             Console.WriteLine("2- Inserir nova Série");
             Console.WriteLine("3- Atualizar série");
             Console.WriteLine("4- Excluir série");
             Console.WriteLine("5- Visualizar série");
             Console.WriteLine("C- Limpar Tela");
             Console.WriteLine("X- Sair");
             Console.WriteLine();

             string opcaoUsuario = Console.ReadLine().ToUpper();
             Console.WriteLine();
             return opcaoUsuario;
        }
    }
}

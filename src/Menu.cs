namespace Aeds3TP1
{
  // classe para representar a "interface", nesse caso a interação do usuário com o terminal
  class Menu
  {
    // método responsável pelo controle do menu principal
    public static void Principal()
    {
      while (true)
      {
        try
        {
          Console.WriteLine(@"Listagem de operações:
  0 - Criar conta bancária
  1 - Realizar transferência
  2 - Ler registro por id
  3 - Ler registro por cidade ou por nome
  4 - Atualizar registro
  5 - Deletar registro
  6 - Compactar arquivo principal
  7 - Descompactar aquivo principal
  8 - Sair");

          var input = Console.ReadLine(); // input do usuário

          if (input == null)
          {
            throw new Exception();
          }

          switch (input)
          {
            case "0":
              // Criar conta bancária
              CriarConta();
              break;

            case "1":
              // Realizar transferência
              Transferencia();
              break;

            case "2":
              // Ler registro
              LerRegistroId();
              break;

            case "3":
              // Ler registro
              LerRegistroId();
              break;

            case "4":
              // Atualizar registro
              AtualizarRegistro();
              break;

            case "5":
              // Deletar registro
              ExcluirRegistro();
              break;

            case "6":
              // Deletar registro
              CompactarArquivo();
              break;

            case "7":
              // Deletar registro
              DesCompactarArquivo();
              break;

            case "8":
              // Sair
              return;

            default:
              throw new Exception();
          }
        }
        catch (Exception)
        {
          Console.WriteLine("Opção inválida.");

          throw;
        }
      }
    }

    // método responsável pelo controle do menu de criação de conta
    static void CriarConta()
    {
      Console.WriteLine("=== Criar conta bancária");

      var conta = new Conta
      {
        Lapide = '\0',
        TotalBytes = 0,
        IdConta = 0,
        NomePessoa = "",
        Cpf = "",
        Cidade = "",
        TransferenciasRealizadas = 0,
        SaldoConta = 1000,
      };

      while (true)
      {
        try
        {
          Console.WriteLine("Digite o nome:");

          var nome = Console.ReadLine(); // input do usuário

          if (nome == null)
          {
            throw new Exception();
          }

          conta.NomePessoa = nome;

          break;
        }
        catch (Exception)
        {
          Console.WriteLine("Nome inválido.");
        }
      }

      while (true)
      {
        try
        {
          Console.WriteLine("Digite o CPF:");

          var cpf = Console.ReadLine(); // input do usuário

          if (cpf == null || cpf.Length != 11)
          {
            throw new Exception();
          }

          conta.Cpf = cpf;

          break;
        }
        catch (Exception)
        {
          Console.WriteLine("CPF inválido.");
        }
      }

      while (true)
      {
        try
        {
          Console.WriteLine("Digite a cidade:");

          var cidade = Console.ReadLine(); // input do usuário

          if (cidade == null)
          {
            throw new Exception();
          }

          conta.Cidade = cidade;

          break;
        }
        catch (Exception)
        {
          Console.WriteLine("Cidade inválida.");
        }
      }

      Program.Write(conta);
    }

    // método responsável pelo controle do menu de transferência
    static void Transferencia()
    {
      Console.WriteLine("=== Realizar transferência");

      Console.WriteLine("Digite o ID da conta a ser debitado o valor:");

      var idInput1 = Console.ReadLine(); // input do usuário

      if (idInput1 == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      var idDebitar = uint.Parse(idInput1);

      var contaDebitar = Conta.PesquisarConta(idDebitar);

      if (contaDebitar == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      Console.WriteLine("Digite o valor a ser debitado:");

      var valorDebitado = Console.ReadLine(); // input do usuário

      if (valorDebitado == null)
      {
        Console.WriteLine("Valor inválido.");

        return;
      }

      var debitar = float.Parse(valorDebitado);

      Console.WriteLine("Digite o ID da conta a ser creditado o valor:");

      var idInput2 = Console.ReadLine(); // input do usuário

      if (idInput2 == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      var idCreditar = uint.Parse(idInput2);

      var contaCreditar = Conta.PesquisarConta(idCreditar);

      if (contaCreditar == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      var resultado = Program.TransferenciaConta(contaDebitar, debitar, contaCreditar);

      if (resultado != null)
        Console.WriteLine(resultado);
    }

    // método responsável pelo controle do menu de leitura de registro
    static void LerRegistroId()
    {
      Console.WriteLine("=== Ler registro");

      Console.WriteLine("Digite o ID da conta a ser lida:");

      var idInput = Console.ReadLine(); // input do usuário

      if (idInput == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      var id = uint.Parse(idInput);

      var conta = Conta.PesquisarConta(id);

      Console.WriteLine(conta);
    }

    static void LerRegistroPessoaCidade()
    {
      Console.WriteLine("=== Ler registro");

      Console.WriteLine("Digite 1 ou 2 (1 - Nome, 2 - Cidade):");

      var num = Console.ReadLine(); // input do usuário

      if (num == null)
      {
        Console.WriteLine("Numero inválido.");

        return;
      }

      var opcao = uint.Parse(num);

      if (opcao != 1 && opcao != 2)
      {
        Console.WriteLine("Numero inválido.");

        return;
      }

      var pessoacidade = Console.ReadLine();

      if (pessoacidade == null)
      {
        Console.WriteLine("Palavra inválida.");

        return;
      }

      var resposta = new List<Conta>();

      if (opcao == 1)
      {
        resposta = Program.PesquisarPessoa(pessoacidade);
      }
      else
      {
        resposta = Program.PesquisarCidade(pessoacidade);
      }
      if (resposta != null)
      {
        for (int i = 0; i < resposta.Count; i++)
        {
          Console.WriteLine(resposta[i]);
        }
      }
      else
      {
        Console.WriteLine("Não houve resultados para a pesquisa.");
      }

    }

    // método responsável pelo controle do menu de exclusão de registro
    static void ExcluirRegistro()
    {
      Console.WriteLine("=== Excluir registro");

      Console.WriteLine("Digite o ID da conta a ser excluida:");

      var idInput = Console.ReadLine(); // input do usuário

      if (idInput == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      var id = uint.Parse(idInput);

      Program.ExcluirId(id);
    }

    // método responsável pelo controle do menu de atualização de registro
    static void AtualizarRegistro()
    {
      Console.WriteLine("=== Atualizar registro");

      Console.WriteLine("Digite o ID da conta a ser alterada:");

      var idInput = Console.ReadLine(); // input do usuário

      if (idInput == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      var id = uint.Parse(idInput);

      var conta = Conta.PesquisarConta(id);

      Console.WriteLine(conta);

      if (conta == null)
      {
        Console.WriteLine("Id inválido.");

        return;
      }

      while (true)
      {
        Console.WriteLine(@"Qual atributo deseja alterar?
0 - Nome
1 - CPF
2 - Cidade
3 - Saldo
4 - Voltar");

        var resposta = Console.ReadLine(); // input do usuário

        if (resposta == null)
        {
          Console.WriteLine("Valor inválido.");

          return;
        }

        switch (resposta)
        {
          case "0":
            try
            {
              Console.WriteLine("Digite o novo nome:");

              var nome = Console.ReadLine(); // input do usuário

              if (nome == null)
              {
                throw new Exception();
              }

              conta.NomePessoa = nome;
            }
            catch (Exception)
            {
              Console.WriteLine("Nome inválido.");
            }

            break;

          case "1":
            try
            {
              Console.WriteLine("Digite o novo CPF:");

              var cpf = Console.ReadLine(); // input do usuário

              if (cpf == null || cpf.Length != 11)
              {
                throw new Exception();
              }

              conta.Cpf = cpf;
            }
            catch (Exception)
            {
              Console.WriteLine("CPF inválido.");
            }

            break;

          case "2":
            try
            {
              Console.WriteLine("Digite a nova cidade:");

              var cidade = Console.ReadLine(); // input do usuário

              if (cidade == null)
              {
                throw new Exception();
              }

              conta.Cidade = cidade;
            }
            catch (Exception)
            {
              Console.WriteLine("Cidade inválida.");
            }

            break;

          case "3":
            try
            {
              Console.WriteLine("Digite o novo saldo:");

              var saldoContaInput = Console.ReadLine(); // input do usuário

              if (saldoContaInput == null)
              {
                throw new Exception();
              }

              var saldoConta = float.Parse(saldoContaInput);

              conta.SaldoConta = saldoConta;
            }
            catch (Exception)
            {
              Console.WriteLine("Saldo inválido.");
            }

            break;

          case "4":
            Program.Update(id, conta);

            return;

          default:
            Console.WriteLine("Digite um valor válido.");

            break;
        }
      }
    }

    static void CompactarArquivo()
    {
      Console.WriteLine("=== Compactar Arquivo");

      Console.WriteLine("Deseja realmente compactar o aquivo principal? (1 - para sim, 2 - para não)");

      var numInput = Console.ReadLine(); // input do usuário

      if (numInput == null)
      {
        Console.WriteLine("Numero inválido.");

        return;
      }

      var num = uint.Parse(numInput);

      if (num == 1)
      {
        var resposta = Program.CompactarContas();
        Console.WriteLine(resposta);
      }
      else if (num == 2)
      {
        return;
      }
      else
      {
        Console.WriteLine("Numero inválido.");

        return;
      }
    }

    static void DesCompactarArquivo()
    {
      Console.WriteLine("=== Descompactar Arquivo");

      Console.WriteLine("Digite o nome do arquivo que deseja descompactar: ");

      var nomeInput = Console.ReadLine(); // input do usuário

      if (nomeInput == null)
      {
        Console.WriteLine("Nome inválido.");

        return;
      }
      //digitar somente dataCompressaoX.dat
      var resposta = Program.DescompactarContas(nomeInput);
      Console.WriteLine(resposta);
    }
  }
}
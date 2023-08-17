using BancoLeo;

List<Cliente> Clientes = new List<Cliente>();
ConsultarCliente();


void ConsultarCliente()
{
    Console.WriteLine("Ola benvindo ao Banco Leo");
    Console.WriteLine("Digite seu codigo");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in Clientes)
    {
        if (cliente == null)
        {
            Console.WriteLine("Este cliente não existe.Deseja cadastrar?Digite S ou N");
            string cadastrarCliente = Console.ReadLine();
            if (cadastrarCliente == "S")
            {
                Console.WriteLine("Digite seu codigo:");
                string CodigoClienteNovo = Console.ReadLine();
                Console.WriteLine("Digite seu Nome:");
                string NomeClienteNovo = Console.ReadLine();
                Console.WriteLine("Digite PF ou PJ");
                string tipoPessoa = Console.ReadLine();
                if (tipoPessoa == "PF")
                    cliente = new PessoaFisica(CodigoClienteNovo, NomeClienteNovo);
                else
                    cliente = new PessoaJuridica(CodigoClienteNovo, NomeClienteNovo);
                Clientes.Add(cliente);
                ExibirMenu(cliente);
            }
            else
                ConsultarCliente();


        }

    }

    void ExibirMenu(Cliente cliente)
    {
        Console.WriteLine($"Ola{cliente.Nome}");
        Console.WriteLine("Digite a opcao desejada:");
        Console.WriteLine("1 -Extrato");
        Console.WriteLine("2 -Saque");
        Console.WriteLine("3 -Deposito");

        string menu = Console.ReadLine();

        switch(menu)
        {
            case "1":
                ExibirExtrato(cliente); 
                break;
            case "2":
                RealizarSaque(cliente);
                break;
            case "3":
                RealizarDeposito(cliente);
                break;
            default:
                Console.WriteLine("Digite a opcao correta");
                ExibirMenu(cliente);
                break;
        }
    }

    void ExibirExtrato()
    {
        Console.WriteLine("*************Etrato**************");
        foreach (Movimentacao nov in cliente.Movimentacoes)
        {
            Console.WriteLine($"{nov.Tipo} - {nov.Valor}");
        }
        Console.WriteLine("Deseja exibir o menu novamente? Digite S ou N");
        string exibirMenu = Console.ReadLine();
        if( exibirMenu == "S" ) 
        {
            ExibirMenu(cliente);
        }
        else
        {
            Console.WriteLine("Deseja consultar outro cliente? Digite S ou N");
            string consultarCliente = Console.ReadLine();
            if (consultarCliente == "S")
                ConsultarCliente();   
        }
    }

    void RealizarSaque(Cliente cliente)
    {
        Console.WriteLine("Digite o valor que deseja sacar:");
        string valor = Console.ReadLine();
        cliente.RealizarSaque(Convert.ToDecimal(valor));
        Console.WriteLine("Deseja Realizar outra transacao? Digite Sou N");
        string realizarOutraTransacao = Console.ReadLine();
        if (realizarOutraTransacao == "S")
            ExibirMenu(cliente);
        else
            Console.WriteLine("Foi um prazer lhe atender! Ate mais!");

    }

    void RealizarDeposito(Cliente cliente)
    {
        Console.WriteLine("Digite o valor que deseja depositar:");
        string valor = Console.ReadLine();
        cliente.RealizarDeposito(Convert.ToDecimal(valor));
        Console.WriteLine("Deseja Realizar outra transacao? Digite Sou N");
        string realizarOutraTransacao = Console.ReadLine();
        if (realizarOutraTransacao == "S")
            ExibirMenu(cliente);
        else
            Console.WriteLine("Foi um prazer lhe atender! Ate mais!");


    }
}
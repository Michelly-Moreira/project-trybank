namespace trybank;

public class Trybank
{
    public bool Logged;
    public int loggedUser;
    
    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;
    public Trybank()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    // 1. Construa a funcionalidade de cadastrar novas contas
    public void RegisterAccount(int number, int agency, int pass)
    {
        for (int register = 0; register < maxAccounts; register++ )
        {
            if((number == Bank[register,0]) && (agency == Bank[register,1]))
                throw new ArgumentException("A conta já está sendo usada!");
        }
        Bank[registeredAccounts,0] = number;
        Bank[registeredAccounts,1] = agency;
        Bank[registeredAccounts,2] = pass;
        Bank[registeredAccounts,3] = 0;

        registeredAccounts++;
    }

    // 2. Construa a funcionalidade de fazer Login
    public void Login(int number, int agency, int pass)
    {
        if (!Logged)
        {
    for (int register = 0; register < registeredAccounts; register++ )
    {
        if((number != Bank[register,0]) || (agency != Bank[register,1]))
        {
            throw new ArgumentException("Agência + Conta não encontrada");
        }
        else
        {
            if((number == Bank[register,0]) && (agency == Bank[register,1]) && (pass == Bank[register,2]))
            {
                Logged = true;
            }
            else
            {
                if((number == Bank[register,0]) && (agency == Bank[register,1]) && (pass != Bank[register,2]))
                {
                    throw new ArgumentException("Senha incorreta");
                }

            }
        }
    } 
        }
        else
        {
            Logged = true;
            throw new AccessViolationException("Usuário já está logado");
        }
    }

    // 3. Construa a funcionalidade de fazer Logout
    public void Logout()
    {
        switch (Logged)
        {
            case true:
                Logged = false;
                break;
            default:
                throw new AccessViolationException("Usuário não está logado");
        };
    }

    // 4. Construa a funcionalidade de checar o saldo
    public int CheckBalance()
    {
        throw new NotImplementedException();   
    }

    // 5. Construa a funcionalidade de depositar dinheiro
    public void Deposit(int value)
    {
        throw new NotImplementedException();
    }

    // 6. Construa a funcionalidade de sacar dinheiro
    public void Withdraw(int value)
    {
        throw new NotImplementedException();
    }

    // 7. Construa a funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        throw new NotImplementedException();
    }

   
}

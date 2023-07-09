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
        for (int index = 0; index < maxAccounts; index++ )
        {
            if((number == Bank[index, 0]) && (agency == Bank[index, 1]))
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
    for (int index = 0; index < registeredAccounts; index++ )
    {
        if((number != Bank[index,0]) || (agency != Bank[index,1]))
        {
            throw new ArgumentException("Agência + Conta não encontrada");
        }
        else
        {
            if((number == Bank[index, 0]) && (agency == Bank[index, 1]) && (pass == Bank[index, 2]))
            {
                Logged = true;
                loggedUser = index;
            }
            else
            {
                if((number == Bank[index,0]) && (agency == Bank[index,1]) && (pass != Bank[index,2]))
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
        try
        {
            return Bank[loggedUser,3];
        }
        catch
        {
            throw new AccessViolationException("Usuário não está logado");
        }   
    }

    // 5. Construa a funcionalidade de depositar dinheiro
    public void Deposit(int value)
    {
        try
        {
            Bank[loggedUser, 3] += value;
        }
        catch
        {
            throw new AccessViolationException("Usuário não está logado");
        }  
    }

    // 6. Construa a funcionalidade de sacar dinheiro
    public void Withdraw(int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        else
        {
            if (Bank[loggedUser, 3] < value)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }
            else
            {
                Bank[loggedUser, 3] -= value;
            }
        }
    }

    // 7. Construa a funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        throw new NotImplementedException();
    }

   
}

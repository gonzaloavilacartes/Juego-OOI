using System;

class Personaje
{
    protected string nombre;
    protected int vida;
    protected int ataque;
    protected Equipo equipo;
    private static Random random = new Random();

    public Personaje(string nombre, int vida, int ataque)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.ataque = ataque;
        this.equipo = new Equipo(0, 0);
    }

    public string GetNombre() => nombre;
    public int GetVida() => vida;
    public int GetAtaque() => ataque + (equipo != null ? equipo.GetModificadorAtaque() : 0);
    public int GetArmadura() => equipo != null ? equipo.GetModificadorArmadura() : 0;

    public void Atacar(Personaje objetivo)
    {
        Console.WriteLine($"{nombre} ataca a {objetivo.GetNombre()}");
        objetivo.RecibirDanio(GetAtaque());
    }

    public void RecibirDanio(int danio)
    {
        if (random.Next(100) < 15) // 15% de esquivar
        {
            Console.WriteLine($"{nombre} esquiva el ataque y recibe 0 de daño.");
            return;
        }

        int dañoFinal = Math.Max(1, danio - GetArmadura());
        vida = Math.Max(0, vida - dañoFinal);
        Console.WriteLine($"{nombre} recibe {dañoFinal} puntos de daño.");
        if (vida == 0)
        {
            Console.WriteLine($"{nombre} ha muerto :(");
        }
    }

    public void Equipar(Equipo equipo)
    {
        this.equipo = equipo;
    }
}

class Sacerdote : Personaje
{
    private static Random random = new Random();
    public Sacerdote(string nombre, int vida, int ataque) : base(nombre, vida, ataque) { }

    public new void RecibirDanio(int danio)
    {
        if (random.Next(4) == 0)
        {
            danio /= 2;
            Console.WriteLine($"Las plegarias de {nombre} han sido escuchadas, daño reducido a la mitad.");
        }
        base.RecibirDanio(danio);
    }
}

class Barbaro : Personaje
{
    private int furia;
    public Barbaro(string nombre, int vida, int ataque, int furia) : base(nombre, vida, ataque)
    {
        this.furia = furia;
    }

    public new void Atacar(Personaje objetivo)
    {
        if (furia >= 3)
        {
            furia -= 3;
            int danio = (int)(GetAtaque() * 1.15);
            Console.WriteLine($"{nombre} ataca furioso a {objetivo.GetNombre()}");
            objetivo.RecibirDanio(danio);
        }
        else
        {
            int danio = GetAtaque() / 2;
            Console.WriteLine($"{nombre} está cansado y su ataque se reduce");
            objetivo.RecibirDanio(danio);
        }
    }
}

class Equipo
{
    protected int modificadorAtaque;
    protected int modificadorArmadura;

    public Equipo(int ataque, int armadura)
    {
        this.modificadorAtaque = ataque;
        this.modificadorArmadura = armadura;
    }

    public int GetModificadorAtaque() => modificadorAtaque;
    public int GetModificadorArmadura() => modificadorArmadura;
}

class Arma : Equipo
{
    public Arma(int ataque) : base(ataque, 0) { }
}

class Armadura : Equipo
{
    public Armadura(int armadura) : base(0, armadura) { }
}

class Juego
{
    public static void Main()
    {
        Personaje darius = new Barbaro("Noxus", 120, 12, 10);
        Personaje garen = new Sacerdote("Demacia", 100, 15);

        Equipo espada = new Arma(5);
        Equipo escudo = new Armadura(3);
        darius.Equipar(espada);
        garen.Equipar(escudo);

        Personaje ganador = Batalla(darius, garen, 5); // Reducir el número de duelos
        if (ganador != null)
        {
            Console.WriteLine($"El ganador es {ganador.GetNombre()}");
        }
        else
        {
            Console.WriteLine("La batalla terminó en empate.");
        }
    }

    public static Personaje Batalla(Personaje p1, Personaje p2, int rondasMax)
    {
        int ronda = 0;
        while (p1.GetVida() > 0 && p2.GetVida() > 0 && ronda < rondasMax)
        {
            p1.Atacar(p2);
            if (p2.GetVida() > 0)
            {
                p2.Atacar(p1);
            }
            ronda++;
        }
        if (p1.GetVida() > 0 && p2.GetVida() > 0)
        {
            return p1.GetVida() > p2.GetVida() ? p1 : p2; // Gana el que tenga más vida al final de las rondas
        }
        else if (p1.GetVida() > 0)
        {
            return p1;
        }
        else if (p2.GetVida() > 0)
        {
            return p2;
        }
        else
        {
            return new Personaje("Nadie", 0, 0); // Retorna un personaje neutral en caso de empate
        }
    }
}

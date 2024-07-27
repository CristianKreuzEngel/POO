using System;
namespace E1;
public class Animal
{
    //Atributos
    private string _nome;
    private string _especie;

    //Propriedades
    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }
    public string Especie
    {
        get { return _especie; }
        set { _especie = value; }
    }
    
    //Métodos
    public void Pular()
    {
        Console.WriteLine($"{_nome} está pulando...");
    }
    //assinaturas
    public void Respirar()
    {
        Console.WriteLine($"{_nome} está a respirar...");
    }
    public bool Respirar(string nome)
    {
       return true;
    }

    
    //Método sobrecarga
    public virtual void EmitirSom()
    {
        Console.WriteLine($"{_nome} está emitindo AQUELE som...");
    }
    
    //Método sobreescrita
    public virtual void Comer()
    {
        Console.WriteLine($"{_nome} está comendo...");
    }
    
    //Construtor
    public Animal(string nome, string especie)
    {
        _nome = nome;
        _especie = especie;
    }

    //Classe filha(sub classe)
    public class Ruga : Animal
    {
        private string _reino;
        private string _cor;

        public string Reino
        {
            get { return _reino; }
            set { _reino = value; }
        }

        public string Cor
        {
            get { return _cor; }
            set { _cor = value; }
        }

        public void Deslizar()
        {
            Console.WriteLine($"{Nome} está deslizando...");
        }
        
        //Construtor da subclasse
        public Ruga(string nome, string especie, string reino, string cor) : base(nome, especie)
        {
            _reino = reino;
            _cor = cor;
        }

        
        // Sobrescrita de método
        public override void EmitirSom()
        {
            Console.WriteLine($"{Nome} está emitindo um som específico da Ruga...");
        }
        public override void Comer()
        {
            Console.WriteLine($"{Nome} está comendo do jeito da Ruga...");
        }
    }
    
}
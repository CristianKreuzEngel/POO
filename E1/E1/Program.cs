using System;
using E1;

var animal = new Animal("Sapo Boi", "R. marinaa");
animal.Pular();
animal.Respirar();
animal.Comer();
animal.EmitirSom();
Console.WriteLine(animal);


Animal.Ruga minhaRuga = new Animal.Ruga("Taturana", "Molusco", "Animalia", "Amarela");
minhaRuga.Pular();
minhaRuga.Respirar();
minhaRuga.Comer();
minhaRuga.EmitirSom();
minhaRuga.Deslizar();
Console.WriteLine(minhaRuga);

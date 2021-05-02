using PersonDBApp.Models;
using PersonDBApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Views
{
    class PersonView : IPersonView
    {
        private readonly IPersonService _personService;

        public PersonView()
        {
            _personService = new PersonService();


        }
        public void CreatePerson()
        {
            Person newPerson = new Person();
            Console.Write("Anna uuden henkilön etunimi: ");
            newPerson.FirstName = Console.ReadLine();
            Console.Write("Anna uuden henkilön sukunimi: ");
            newPerson.LastName = Console.ReadLine();
            Console.Write("Anna uuden henkilön sukupuoli: ");
            newPerson.Sex = Console.ReadLine();
            Console.Write("Anna uuden henkilön kaupunki: ");
            newPerson.City = Console.ReadLine();


            newPerson = _personService.Create(newPerson);
            if (newPerson != null)
            {
                Console.WriteLine("Henkilön lisääminen onnistui");
            }
            else
            {
                Console.WriteLine("Henkilön lisääminen epäonnistui");
            }
        }

        public void DeletePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);

            _personService.Delete(id);
        }

        public void PrintAllPeople()
        {
            var people = _personService.Read();
            PrintPeople(people);
        }

        public void PrintByCity()
        {
            Console.Write("Syötä kaupungin nimi:");
            string city = Console.ReadLine();
            var people = _personService.Read(city);
            PrintPeople(people);
        }

        public void PrintSinglePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            PrintPerson(person);
        }

        public void UpdatePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);

            //Kysy uudet arvot
            Console.Write("Anna henkilön uusi etunimi: ");
            person.FirstName = Console.ReadLine();
            Console.Write("Anna henkilön uusi sukunimi: ");
            person.LastName = Console.ReadLine();
            Console.Write("Anna henkilön uusi sukupuoli: ");
            person.Sex = Console.ReadLine();
            Console.Write("Anna henkilön uusi kaupunki: ");
            person.City = Console.ReadLine();

            _personService.Update(id, person);
            if (person != null)
            {
                Console.WriteLine("Henkilön lisääminen onnistui");
            }
            else
            {
                Console.WriteLine("Henkilön lisääminen epäonnistui");
            }
        }

        private void PrintPeople(List<Person>people)
        {
            Console.WriteLine("Id\tEtunimi\tSukunimi\tSukupuoli\tKaupunki");
            foreach (var p in people)
            {
                PrintPerson(p);
            }
        }
        private void PrintPerson(Person p)
        {
            Console.WriteLine($"{p.Id}\t{p.FirstName}\t{p.LastName}\t{p.Sex}\t{p.City}");
        }
    }
}

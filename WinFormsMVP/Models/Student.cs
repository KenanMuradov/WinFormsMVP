﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMVP.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public float Score { get; set; }

    public Student() => Id = Guid.NewGuid();

    public Student(string firstName, string lastName, DateTime birthDate, float score)
        : this()
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Score = score;
    }


    public override string ToString()=>
        $@"Id: {Id.ToString().Remove(8)}    FirstName: {FirstName}    LastName: {LastName}    DateOfBirth: {BirthDate.ToShortDateString()}    Score: {Score}";

}

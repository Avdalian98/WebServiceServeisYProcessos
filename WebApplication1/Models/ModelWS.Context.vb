﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class contactes2Entities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=contactes2Entities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property contacte() As DbSet(Of contacte)
    Public Overridable Property email() As DbSet(Of email)
    Public Overridable Property telefon() As DbSet(Of telefon)

    Public Overridable Function Prueba(name As String, lastname As String) As Integer
        Dim nameParameter As ObjectParameter = If(name IsNot Nothing, New ObjectParameter("name", name), New ObjectParameter("name", GetType(String)))

        Dim lastnameParameter As ObjectParameter = If(lastname IsNot Nothing, New ObjectParameter("lastname", lastname), New ObjectParameter("lastname", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("Prueba", nameParameter, lastnameParameter)
    End Function

End Class

using System;
using EntidadesAbstractas = Clases_Abstractas;
using Excepciones;
using Clases_Instanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using System.Diagnostics;
using System.Collections;

namespace Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456xj",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12458962",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            uni += a1;
            uni += a1;

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Alessandra", "Fernandes", "12458962",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            Universidad uni = new Universidad();

            uni += Universidad.EClases.SPD;
            uni += Universidad.EClases.Legislacion;
            uni += Universidad.EClases.Programacion;
            uni += Universidad.EClases.Laboratorio;

            Assert.Fail();
        }

        [TestMethod]
        public void TestInstanciacionColeection()
        {
            Universidad uni = new Universidad();

            bool isCollection = typeof(IEnumerable).IsInstanceOfType(uni.Alumnos);

            Assert.IsTrue(isCollection);
        }

        [TestMethod]
        public void TestCantidadAlumnos()
        {
            Universidad uni = new Universidad();

            Alumno a1 = new Alumno(1, "Alessandra", "Fernandes", "12458962",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);

            Alumno a2 = new Alumno(2, "Juan", "Lopez", "92264488",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD,
            Alumno.EEstadoCuenta.Becado);

            Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234486",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);

            uni += a1;
            uni += a2;
            uni += a3;

            Assert.IsTrue(uni.Alumnos.Count == 3);
        }

        [TestMethod]
        public void TestMetodoEquals()
        {
            Universidad uni = new Universidad();
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            Assert.IsFalse(uni.Equals(i2));
        }


    }
}

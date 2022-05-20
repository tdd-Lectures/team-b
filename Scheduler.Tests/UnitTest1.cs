using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Scheduler.Tests
{
    
    // API
    // CreateAppointment(...)
    // GetAppointments(...)
    public class Tests
    {
        [Test]
        public void Creating_an_appointment_returns_the_new_appointment_identifier()
        {
            var scheduler = new Scheduler1();

            var identifier = scheduler.CreateAppointment();

            Assert.That(identifier, Is.Not.Null);
        }
        
        [Test]
        public void Creating_an_appointment_persists_the_new_appointment()
        {
            var scheduler = new Scheduler1();

            var identifier = scheduler.CreateAppointment();
            // appt -> appointment
            var appt = scheduler.GetById(identifier);

            Assert.That(appt, Is.Not.Null);
            Assert.That(appt, Is.TypeOf<Appointment>()); // Type Check
            Assert.That(appt.identifier, Is.EqualTo(identifier));
        }
        
        [Test]
        public void Getting_by_id_non_existing_appointment_returns_null()
        {
            var scheduler = new Scheduler1();
            
            var appt = scheduler.GetById(1);
            
            Assert.That(appt, Is.Null);
        }
        
        [Test]
        public void Creating_2_appointments_returns_2_distinct_identifiers()
        {
            var scheduler = new Scheduler1();
            
            var appointment1Id = scheduler.CreateAppointment();
            var appointment2Id = scheduler.CreateAppointment();
            
            Assert.That(appointment1Id,Is.Not.EqualTo(appointment2Id));
        }
    }

    // TODO: Scheduler1 -> rename needed
    public class Scheduler1
    {
        // TODO: Split: Business Rules Scheduler1 | Data from elsewhere 
        // Violates: SRP, OCP 
        List<Appointment> appointments = new List<Appointment>();
        public object CreateAppointment()
        {
            // TODO: Use object initializer
            // TODO: Use var
            Appointment appointment = new Appointment();
            appointment.identifier = appointments.Count;
            appointments.Add(appointment);
            return appointment.identifier;
        }

        internal Appointment GetById(object identifier)
        {
            // TODO: inline
            var appt = appointments.FirstOrDefault(a => a.identifier == identifier);
            return appt;
        }
    }
}
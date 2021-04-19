using MailSender.lib.Entities;
using MailSender.lib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Tests.Services.InMemory
{
    /// <summary>
    /// Сводное описание для InMemoryRecipientsDataProviderTests
    /// </summary>
    [TestClass]
    public class InMemoryRecipientsDataProviderTests
    {
        [AssemblyInitialize]
        public static void TestAssembly_Initialize(TestContext context)
        {

        }

        [ClassInitialize]
        public static void TestClass_Initialize(TestContext context)
        {

        }

        [TestInitialize]
        public void Test_Initialize()
        {

        }

        [TestCleanup]
        public void Test_Cleanup()
        {

        }

        [ClassCleanup]
        public static void TestClass_Cleanup()
        {

        }

        [AssemblyCleanup]
        public static void TestAssembly_Cleanup()
        {

        }

        public InMemoryRecipientsDataProviderTests()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateNewRecipientInEmptyProvider()
        {
            var data_provider = new InMemoryRecipientsDataProvider();

            var expected_recipient_name = "Получатель1";
            var expected_recipient_adress = "recipient1@server.com";
            var expected_id = 1;

            var new_recipient = new Recipient
            {
                Name = expected_recipient_name,
                Adress = expected_recipient_adress
            };

            data_provider.Create(new_recipient);

            var actual_id = new_recipient.ID;
            var actual_recipient = data_provider.GetByID(1);

            Assert.AreEqual(expected_id, actual_id);
            Assert.AreEqual(expected_recipient_name, actual_recipient.Name);
            Assert.AreEqual(expected_recipient_adress, actual_recipient.Adress);

            //StringAssert.Matches("value_string", new System.Text.RegularExpressions.Regex(@"\w+\s\w+"));

            if (expected_id != actual_id)
                throw new AssertFailedException("Идентификаторы не совпадают");
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using DocumentLib;
using operation;

namespace VectorText
{
    [TestClass]
    public class UnitTestDocument
    {
        [TestMethod]
        public void ReadFromFile()
        {
            string path = "test.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Рассказывают, что древние греки очень любили" +
                    " виноград и после его сбора устраивали праздник в честь" +
                    " бога винограда Диониса. Свиту Диониса составляли" +
                    " козлоногие существа — сатиры. Изображая их, эллины" +
                    " надевали козлиные шкуры, бешено скакали и пели — словом," +
                    " самозабвенно предавались веселью. Такие представления" +
                    " назывались трагедиями, что по-древнегречески означало" +
                    " «пение козлов». Впоследствии эллины призадумались:" +
                    " чему бы еще посвятить такие игрища? Простым людям всегда" +
                    " было интересно знать, как живут богатые." +
                    " Драматург Софокл начал писать пьесы про царей," +
                    " и сразу стало ясно: цари и те часто плачут и личная" +
                    " жизнь у них небезопасна и отнюдь не проста. А для того" +
                    " чтобы придать повествованию занимательности, Софокл решил" +
                    " привлечь актеров, которые смогли бы сыграть его" +
                    " произведения, — так появился театр. ");
            }
            Document doc = new Document(path, TextOrPath.Path);
            double norm = Document.NormVector(doc.vector);
            Assert.IsTrue(Math.Abs(norm - 1) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void ReadString()
        {
            Document v1 = new Document("a, b, c, c");
            double norm = Document.NormVector(v1.vector);
            Assert.IsTrue(Math.Abs(norm - 1) < Math.Pow(10, -8));
        }
    }

    [TestClass]
    public class UnitTestOperation
    {

        [TestMethod]
        public void CosCollen()
        {
            string path = "test.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("a b c");
            }
            Document v1 = new Document(path, TextOrPath.Path);
            Document v2 = new Document(path, TextOrPath.Path);
            Assert.IsTrue(Math.Abs(Operation.Cos(v1, v2) - 1) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void RightAngel()
        {
            Document v1 = new Document("b");
            Document v2 = new Document("a");
            Assert.IsTrue(Math.Abs(Operation.Cos(v1, v2)) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void ZeroVector()
        {
            Document v1 = new Document("");
            Document v2 = new Document("aaa");
            Assert.IsTrue(Math.Abs(Operation.Cos(v1, v2)) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void Cos()
        {
            Document v1 = new Document("a a b b");
            Document v2 = new Document("b b");
            Assert.IsTrue(Math.Abs(Operation.Cos(v1, v2) - Math.Sqrt(2) / 2) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void Cos2()
        {
            Document v1 = new Document("a a b b c ");
            Document v2 = new Document("b b a c");
            Assert.IsTrue(Math.Abs(Operation.Cos(v1, v2) - Math.Sqrt(6) * 7 / 18) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void Practice()
        {
            Document v1 = new Document("В психологии прокрастинация — это" +
                " склонность человека к постоянному откладыванию дел на потом," +
                " даже если они важны и требуют срочного внимания. Такое поведение," +
                " как правило, приводит к жизненным проблемам, а также к стрессу," +
                " потере работоспособности и производительности, чувству вины," +
                " заниженной самооценке.");

            Document v2 = new Document("Прокрастинация — это вид саморазрушительного поведения," +
                " при котором человек откладывает решение задач на последний момент." +
                " Нередко это сопровождается чувством вины и даже своеобразного паралича" +
                " воли. В психологических исследованиях отмечается, что прокрастинатор" +
                " осознает иррациональность своего бездействия и негативные последствия," +
                " к которым такое поведение может привести.");

            Document v3 = new Document("Совесть — способность личности самостоятельно" +
                " формулировать нравственные обязанности и реализовывать нравственный" +
                " самоконтроль, требовать от себя их выполнения и производить оценку" +
                " совершаемых ею поступков; одно из выражений нравственного самосознания" +
                " личности. Проявляется и в форме рационального осознания нравственного" +
                " значения совершаемых действий, и в форме эмоциональных переживаний" +
                " — чувства вины или «угрызений совести», то есть связывает воедино" +
                " разум и эмоции. ");

            Assert.IsTrue(Math.Abs(Operation.Cos(v1, v2)) > Math.Abs(Operation.Cos(v1, v3)));
            Assert.IsTrue(Math.Abs(Operation.Cos(v1, v2)) > Math.Abs(Operation.Cos(v2, v3)));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace VectorText
{
    [TestClass]
    public class UnitTest
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
            VectorText vectorText = new VectorText(path, TextOrPath.Path);
            double norm = VectorText.NormVector(vectorText.vector);
            Assert.IsTrue(Math.Abs(norm - 1) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void ReadString()
        {
            VectorText v1 = new VectorText("a, b, c, c");
            double norm = VectorText.NormVector(v1.vector);
            Assert.IsTrue(Math.Abs(norm - 1) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void CosCollen()
        {
            string path = "test.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("a b c");
            }
            VectorText v1 = new VectorText(path);
            VectorText v2 = new VectorText(path);
            Assert.IsTrue(Math.Abs(VectorText.Cos(v1, v2) - 1) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void RightAngel()
        {
            VectorText v1 = new VectorText("b");
            VectorText v2 = new VectorText("a");
            Assert.IsTrue(Math.Abs(VectorText.Cos(v1, v2)) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void ZeroVector()
        {
            VectorText v1 = new VectorText("");
            VectorText v2 = new VectorText("aaa");
            Assert.IsTrue(Math.Abs(VectorText.Cos(v1, v2)) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void Cos()
        {
            VectorText v1 = new VectorText("a a b b");
            VectorText v2 = new VectorText("b b");
            Assert.IsTrue(Math.Abs(VectorText.Cos(v1, v2) - Math.Sqrt(2)/2) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void Cos2()
        {
            VectorText v1 = new VectorText("a a b b c ");
            VectorText v2 = new VectorText("b b a c");
            Assert.IsTrue(Math.Abs(VectorText.Cos(v1, v2) - Math.Sqrt(6) * 7 / 18) < Math.Pow(10, -8));
        }

        [TestMethod]
        public void Practice()
        {
            VectorText v1 = new VectorText("В психологии прокрастинация — это" +
                " склонность человека к постоянному откладыванию дел на потом," +
                " даже если они важны и требуют срочного внимания. Такое поведение," +
                " как правило, приводит к жизненным проблемам, а также к стрессу," +
                " потере работоспособности и производительности, чувству вины," +
                " заниженной самооценке.");

            VectorText v2 = new VectorText("Прокрастинация — это вид саморазрушительного поведения," +
                " при котором человек откладывает решение задач на последний момент." +
                " Нередко это сопровождается чувством вины и даже своеобразного паралича" +
                " воли. В психологических исследованиях отмечается, что прокрастинатор" +
                " осознает иррациональность своего бездействия и негативные последствия," +
                " к которым такое поведение может привести.");

            VectorText v3 = new VectorText("Совесть — способность личности самостоятельно" +
                " формулировать нравственные обязанности и реализовывать нравственный" +
                " самоконтроль, требовать от себя их выполнения и производить оценку" +
                " совершаемых ею поступков; одно из выражений нравственного самосознания" +
                " личности. Проявляется и в форме рационального осознания нравственного" +
                " значения совершаемых действий, и в форме эмоциональных переживаний" +
                " — чувства вины или «угрызений совести», то есть связывает воедино" +
                " разум и эмоции. ");

            Assert.IsTrue(Math.Abs(VectorText.Cos(v1, v2)) > Math.Abs(VectorText.Cos(v1, v3)));
            Assert.IsTrue(Math.Abs(VectorText.Cos(v1, v2)) > Math.Abs(VectorText.Cos(v2, v3)));
        }

        
    }
}

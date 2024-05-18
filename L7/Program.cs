using Microsoft.Office.Interop.Word;

namespace L7
{
    class Program
    {
        static public void Main()
        {
            Application app = new Application();
            
            string docname = GetStringInput("Введите название отчёта: ");
            string num = GetStringInput("Введите номер лабораторной работы: ");
            string theme = GetStringInput("Введите тему лабораторной работы: ");
            string fname = GetStringInput("Введите Фамилию И.О.: ");
            string spec = GetStringInput("Введите вашу специальность: ");
            string group = GetStringInput("Введите вашу группу: ");
            string teach = GetStringInput("Введите Фамилию И.О. преподавателя: ");

            try
            {
                // копирование шаблона
                string path = Environment.CurrentDirectory + "\\Template.docx";
                string newPath = Environment.CurrentDirectory + $"\\{docname}.docx";
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                    fileInf.CopyTo(newPath, true);

                Document document = app.Documents.Open(newPath);
                Selection selection = app.Selection;
                selection.Move(WdUnits.wdWord, 52);
                selection.TypeText(num);
                selection.Move(WdUnits.wdWord, 4);
                selection.TypeText(theme);
                selection.Move(WdUnits.wdWord, 3);
                selection.TypeText(fname);
                selection.Move(WdUnits.wdWord, 12);
                selection.TypeText(spec);
                selection.Move(WdUnits.wdWord, 3);
                selection.TypeText(group);
                selection.Move(WdUnits.wdWord, 3);
                selection.TypeText(teach);
                selection.Move(WdUnits.wdWord, 15);
                selection.TypeText(DateTime.Now.Year.ToString());

                document.SaveAs2(newPath,
                    WdSaveFormat.wdFormatDocumentDefault,
                    ReadOnlyRecommended: false,
                    EmbedTrueTypeFonts: true);
                document.Close();
            }
            catch (Exception e)
            {
                app.Quit();
                Console.WriteLine(e.Message);
                return;
            }
            
            app.Quit();
        }

        static public string GetStringInput(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
    }
}
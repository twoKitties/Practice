using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Script
{
    class Program
    {
        static void Main(string[] args)
        {
            Page page1 = new Page(new string[] { "he had a lot to say", "blutter got right on top of me" });
            Page page2 = new Page(new string[] { "london is the capital of the great britain", "lock, stock, two smoking barrels" });
            PageReader pageReader = new PageReader();
            pageReader.Show(page1, page2);
            FileReader fileReader = new FileReader();
            fileReader.Show("c://temp");
            Console.ReadLine();
        }
    }

    class Page
    {
        public string[] Lines { get; }

        public Page(params string[] lines)
        {
            Lines = lines;
        }
    }

    class PageReader
    {
        public void Show(params Page[] pages)
        {
            foreach (var page in pages)
            {
                foreach(var line in page.Lines)
                {
                    Console.WriteLine(line);
                }
                Thread.Sleep(1000);
            }
        }
    }

    class FileReader
    {
        private PageReader _pageReader;
        private const string EXT = ".txt";

        public FileReader()
        {
            _pageReader = new PageReader();
        }

        public void Show(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                var files = GetFiles(dirPath);
                var pages = new Page[files.Length];
                for (int i = 0; i < pages.Length; i++)
                    pages[i] = ConvertToPages(File.ReadAllLines(files[i].FullName));

                _pageReader.Show(pages);
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }

        private FileInfo[] GetFiles(string dirPath) => new DirectoryInfo(dirPath).EnumerateFiles($"*{EXT}").Where(pages => IsDigit(pages.Name)).ToArray();

        private bool IsDigit(string s)
        {
            s = s.Replace(EXT, string.Empty);
            foreach (char c in s)
                if (c < '0' || c > '9')
                    return false;

            return true;
        }

        private Page ConvertToPages(string[] lines) => new Page(lines);
    }
}

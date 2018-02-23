using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Angkor.O7Framework.Utility
{
    public class Page
    {
        public int Number { get; set; }

        public string Url { get; set; }

        public Page(int number, string url)
        {
            this.Number = number;
            this.Url = url;
        }
    }
    public static class O7PaginationManager
    {

        private static List<Page> GetPages(int numItemsPerPages, int numPagesToShow, int currentPage, int totalItems
            , int range, string url, bool haveQueryString, out string flgBegin, out string flgEnd,
            out string prevPage, out string nextPage, out string isBegin, out string isEnd)
        {
            if (numPagesToShow % 2 != 0)
                numPagesToShow += 1;
            var pages = new List<Page>();
            int numPages = (int)Math.Ceiling((double)totalItems / (double)numItemsPerPages);
            if (numPages == 0)
                numPages = 1;
            int pageIni = currentPage - range;

            int pageFin = currentPage + range;

            if (pageIni <= 1)
            {
                pageIni = 1;
                pageFin += 2;
                flgBegin = "true";
            }
            else
            {
                flgBegin = "false";
            }

            if (pageFin >= numPages)
            {
                pageFin = numPages;
                pageIni -= 2;
                if (pageIni <= 1)
                {
                    pageIni = 1;
                    flgBegin = "true";
                }
                else
                {
                    flgBegin = "false";
                }
                flgEnd = "false";
            }
            else
            {
                flgEnd = "true";
            }
            var car = "?";
            if (url.Contains("?"))
                car = "&";
            url += car;
            for (int i = pageIni; i <= pageFin; i++)
            {
                pages.Add(new Page(i, url + "PageNumber=" + i.ToString()));
            }

            var indexPrev = currentPage - 1;
            if (indexPrev <= 0)
            {
                prevPage = "";
            }
            else
            {
                prevPage = url + "PageNumber=" + indexPrev.ToString();
            }

            var indexNext = currentPage + 1;
            if (indexNext > numPages)
            {
                nextPage = "";
            }
            else
            {
                nextPage = url + "PageNumber=" + indexNext.ToString();
            }
            if (currentPage <= 1)
            {
                isBegin = "true";
            }
            else
            {
                isBegin = "false";
            }
            if (currentPage >= numPages)
            {
                isEnd = "true";
            }
            else
            {
                isEnd = "false";
            }

            return pages;
        }

        public static int NumItemsPerPage { get; set; } = 8;

    public static void SetPagination(ViewDataDictionary ViewData,int numPage, int numItems, string url, bool HaveQueryString)
        {
            string flgBegin;
            string flgEnd;
            string prevPage;
            string nextPage;
            string isBegin;
            string isEnd;
            var pages = GetPages(NumItemsPerPage, 5, numPage, numItems, 2, url, HaveQueryString, out flgBegin, out flgEnd, out prevPage, out nextPage, out isBegin, out isEnd);
            ViewData["pages"] = pages;
            ViewData["currentPage"] = numPage;
            ViewData["flgBegin"] = flgBegin;
            ViewData["flgEnd"] = flgEnd;
            ViewData["prevPage"] = prevPage;
            ViewData["nextPage"] = nextPage;
            ViewData["isBegin"] = isBegin;
            ViewData["isEnd"] = isEnd;
        }
    }
 }


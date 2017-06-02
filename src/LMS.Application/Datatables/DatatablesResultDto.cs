using System.Collections.Generic;

namespace LMS.Datatables
{
    public class DatatablesResultDto<T> where T: new()
    {
        public DatatablesResultDto()
        {
        }

        public DatatablesResultDto(int drawParam, int recordsTotalParam, int recordsFilteredParam, IReadOnlyList<T> dataParam, string errorParam)
        {
            draw = drawParam;
            recordsTotal = recordsTotalParam;
            recordsFiltered = recordsFilteredParam;
            data = dataParam;
            error = errorParam;
        }

        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public IReadOnlyList<T> data { get; set; }

        public string error { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ZKKADotNetCore.WebApiNLayer.Features.Proverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProverbController : ControllerBase
    {
        private async Task<ProverbsDto> GetDataAsync()
        {
            String jsonStr = await System.IO.File.ReadAllTextAsync("mmProverb.json");
            var model = JsonConvert.DeserializeObject<ProverbsDto>(jsonStr);
            return model;
        }

        [HttpGet("FirstLetter")]
        public async Task<IActionResult> FirstLetter()
        {
            var model = await GetDataAsync();

            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("{titleName}")]
        public async Task<IActionResult> ProverbTitles(string titleName)
        {
            var model = await GetDataAsync();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null) return NotFound("no data");

            var titleId = item.TitleId;
            var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
            
            List<Tbl_MmproverbsWithoutDescp> lst = result.Select(x => new Tbl_MmproverbsWithoutDescp
            {
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName,
                TitleId = x.TitleId
            }).ToList();//without description
            return Ok(lst);
        }

        [HttpGet("{titleId}/{proverbId}")]

        public async Task<IActionResult> Proverb(int titleId, int proverbId)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs.FirstOrDefault(x =>x.TitleId == titleId && x.ProverbId == proverbId));
        }
    }


    public class ProverbsDto
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_Mmproverbs
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }

    public class Tbl_MmproverbsWithoutDescp
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }

    }
}

using Challenge03.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Category.Pages
{
    public class CategoryModel : PageModel
    {
        /*HttpClient:Đây là một lớp trong thư viện System.Net.Http của .NET, 
        dùng để gửi các yêu cầu HTTP và nhận phản hồi từ một resource trên web*/
        private readonly HttpClient _httpClient;
        
        private const string BaseUrl = "http://localhost:5017";

        public CategoryModel(HttpClient httpClient)
        {
            // cho phép lớp sử dụng instance HttpClient được cung cấp
            _httpClient = httpClient;
        }

        public List<CategoryDto> Categories { get; set; } = new(); //new():Khởi tạo Categories với một danh sách rỗng

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CategoryDto>>($"{BaseUrl}/categories");
            /*
            GetFromJsonAsync: : Gửi một yêu cầu HTTP GET đến một URI và 
            tự động deserialization nội dung JSON của phản hồi 
            thành một đối tượng hoặc danh sách các đối tượng của kiểu dữ liệu cụ thể.

            GetAsync: cho phép bạn xử lý phản hồi từ server mà không tự động chuyển đổi thành kiểu dữ liệu cụ thể.

            */
            
            if (response != null)
            {
                Categories = response;
            }
            else
            {
                Categories = new List<CategoryDto>();
            }
        }
    }
}

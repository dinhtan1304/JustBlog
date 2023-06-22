using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Areas.Identity.Pages.Role
{
    [Area("Admin")]
    [Authorize(Roles = "Blog_Owner")]
    public class AddModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AddModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [TempData] // Sử dụng Session
        public string StatusMessage { get; set; }
        public class InputModel
        {
            public string ID { set; get; }

            [Required(ErrorMessage = "Phải nhập tên role")]
            [Display(Name = "Tên của Role")]
            [StringLength(100, ErrorMessage = "{0} dài {2} đến {1} ký tự.", MinimumLength = 3)]
            public string Name { set; get; }

        }
        [BindProperty]
        public InputModel Input { set; get; }

        [BindProperty]
        public bool IsUpdate { set; get; }

        // Không cho truy cập trang mặc định mà không có handler
        public IActionResult OnGet() => NotFound("Không thấy");
        public IActionResult OnPost() => NotFound("Không thấy");
        public IActionResult OnPostStartNewRole()
        {
            StatusMessage = "Hãy nhập thông tin để tạo role mới";
            IsUpdate = false;
            ModelState.Clear();
            Input.ID = "1";
            return Page();
        }
        // Truy vấn lấy thông tin Role cần cập nhật
        public async Task<IActionResult> OnPostStartUpdate()
        {
            StatusMessage = null;
            IsUpdate = true;
            if (Input.ID == null)
            {
                StatusMessage = "Error: Không có thông tin về Role";
                return Page();
            }
            var result = await _roleManager.FindByIdAsync(Input.ID);
            if (result != null)
            {
                Input.Name = result.Name;
                ViewData["Title"] = "Cập nhật role : " + Input.Name;
                ModelState.Clear();
            }
            else
            {
                StatusMessage = "Error: Không có thông tin về Role ID = " + Input.ID;
            }

            return Page();
        }

        // Cập nhật hoặc thêm mới tùy thuộc vào IsUpdate
        public async Task<IActionResult> OnPostAddOrUpdate()
        {

            if (!ModelState.IsValid)
            {
                StatusMessage = null;
                return Page();
            }

            if (IsUpdate)
            {
                return await UpdateRole();
            }
            else
            {
                return await AddRole();
            }

        }

        private async Task<IActionResult> UpdateRole()
        {
            if (Input.ID == null)
            {
                StatusMessage = "Error: not found roleId";
                return Page();
            }

            var result = await _roleManager.FindByIdAsync(Input.ID);

            if (result != null)
            {
                result.Name = Input.Name;

                var roleUpdateRs = await _roleManager.UpdateAsync(result);

                if (roleUpdateRs.Succeeded)
                {
                    StatusMessage = "Update Role Success!";
                    return RedirectToPage("./Index");
                }
                else
                {
                    StatusMessage = "Error: ";
                    foreach (var er in roleUpdateRs.Errors)
                    {
                        StatusMessage += er.Description;
                    }
                }
            }
            else
            {
                StatusMessage = "Error: Not found role";
            }

            return Page();
        }
        private async Task<IActionResult> AddRole()
        {
            var newRole = new IdentityRole() { Name = Input.Name };

            var rsNewRole = await _roleManager.CreateAsync(newRole);

            if (rsNewRole.Succeeded)
            {
                StatusMessage = "Add role success!";
                return RedirectToPage("./Index");
            }
            else
            {
                StatusMessage = "Error: ";
                foreach (var er in rsNewRole.Errors)
                {
                    StatusMessage += er.Description;
                }
            }

            return Page();
        }
    }
}

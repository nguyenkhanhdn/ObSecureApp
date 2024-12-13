using Microsoft.AspNetCore.Mvc;

namespace ObSecureApp.Controllers
{
    public class RuleController : Controller
    {
        private readonly RuleRepository _repository = new RuleRepository();

        // GET: Rule
        public IActionResult Index()
        {
            var rules = _repository.GetAll();
            return View(rules);
        }

        // GET: Rule/Details/1
        public IActionResult Details(int id)
        {
            var rule = _repository.GetById(id);
            if (rule == null)
            {
                return NotFound();
            }
            return View(rule);
        }

        // GET: Rule/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, int priority, string type, string url)
        {
            List<string> strings = new List<string>();
            strings.Add("main_frame");

            Action action = new Action(type);
            action.Type = type;

            Condition condition = new Condition();
            condition.urlFilter = url;
            condition.resourceTypes = strings;
            
            RuleModel rule = new RuleModel();
            rule.Id = id;
            rule.Priority = priority;
            rule.Action = action;
            rule.Condition = condition;

            
            _repository.Create(rule);
            return RedirectToAction(nameof(Index));

        }

        // GET: Rule/Edit/1
        public IActionResult Edit(int id)
        {
            var rule = _repository.GetById(id);
            if (rule == null)
            {
                return NotFound();
            }
            return View(rule);
        }

        // POST: Rule/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RuleModel rule)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(rule);
                return RedirectToAction(nameof(Index));
            }
            return View(rule);
        }

        // GET: Rule/Delete/1
        public IActionResult Delete(int id)
        {
            var rule = _repository.GetById(id);
            if (rule == null)
            {
                return NotFound();
            }
            return View(rule);
        }

        // POST: Rule/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

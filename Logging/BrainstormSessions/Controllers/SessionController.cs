using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof(SessionController));
        
        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            _logger.Info("Open index.cshhtml Session controller");

            if (!id.HasValue)
            {
                _logger.Warn($"{nameof(Index)} id has not value!");
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            _logger.Debug($"{nameof(Index)} id has value");

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                _logger.Warn($"{nameof(Index)} session is null!");
                return Content("Session not found.");
            }

            _logger.Debug($"{nameof(Index)} session not null");

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            return View(viewModel);
        }
    }
}

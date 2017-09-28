using BeerDrinking.Behaviors;
using BeerDrinking.Helpers;
using DryIoc;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using FormsPlugin.Iconize;

namespace BeerDrinking
{
    public class DynamicTabbedPage : IconTabbedPage, INavigatingAware
    {
        private IContainer _container { get; }

        public DynamicTabbedPage(IContainer container)
        {
            _container = container;
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            var tabs = parameters.GetValues<string>(AppConstants.DynamicTabKey);
            foreach (var tabSegment in tabs)
            {
                Page page = null;

                var uri = UriParsingHelper.Parse(tabSegment);
                foreach (var segment in UriParsingHelper.GetUriSegments(uri))
                {
                    if (page != null && !(page is NavigationPage)) continue;

                    var segmentPage = CreatePage(UriParsingHelper.GetSegmentName(segment));
                    segmentPage.Behaviors.Add(new IsActiveAwareBehavior());
                    PageUtilities.OnNavigatingTo(segmentPage,
                                                 UriParsingHelper.GetSegmentParameters(segment, parameters));
                    switch (page)
                    {
                        case null:
                            page = segmentPage;
                            break;
                        case NavigationPage navPage:
                            await navPage.PushAsync(segmentPage);
                            break;
                    }
                }

                Children.Add(page);
            }

        }
        protected virtual Page CreatePage(string childName)
        {
            var page = _container.Resolve<object>(childName) as Page;
            if (ViewModelLocator.GetAutowireViewModel(page) == null)
            {
                ViewModelLocator.SetAutowireViewModel(page, true);
            }

            return page;
        }
    }
}
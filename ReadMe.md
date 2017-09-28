# Beer Drinking

Data is relational, and the database in your Mobile App should be too. The Beer Drinking app demonstrates using the Realm Mobile Database for relating Breweries with the Beers they brew.

### Prerequisites

Make sure you have checked out the general [Meetup Prerequisites](https://github.com/SDXamarinDevs/Meetups)

## Level 0

- Register the views with the Container
- Update the Navigation Commands
- Pass the necessary object from page to page
- Run the app

### Navigation

Prism Navigation Service is Uri based. It can work with either a Uri string or an actual Uri object. Take `"ViewA/ViewB/ViewC"` for example. Given this Navigation Uri it will push ViewA, then ViewB, then ViewC onto the Navigation Stack. If however you make this an absolute Uri (`"/ViewA/ViewB"`)it will reset the Navigation Stack making the first View in the Uri the Root View of the Application. The Navigation Service doesn't stop there though as it is able to handle both Xamarin Forms NavigationPage and MasterDetailPage intellegently. For instance the Navigation Uri `"NavigationPage/ViewA"` will create an empty NavigationPage with ViewA as the root Page, and `"NavigationPage/ViewA/ViewB"` will display ViewB with a Back button in the Navigation Bar to navigate back to ViewA. The Navigation Service can handle MasterDetailPage's much the same way by taking the following View and setting it as the Detail of the MasterDetailPage.

#### Handling MasterDetailPages

Upon closer inspection you will notice that the `MainPage` is actually a MasterDetailPage. The Master is hard coded in the XAML, however no Detail is defined. Note that this does not need to be changed. To handle MasterDetailPages you will end up with a NavigationUri similar to `"MasterDetailPage/NavigationPage/ViewA"`, this will display ViewA with the Hamburger Menu and a slide out menu.

#### Dynamic Tabbed Page

The Prism QuickStart Template, which this project was created with includes a DynamicTabbedPage which is already registered for you using the key `TabbedPage`. You will notice that this allows you to generically create TabbedPages by passing in querystring parameters to create tabs like: `"TabbedPage?tab=ViewA&tab=ViewB"`. After creating the tab it will then attach Prism's AutoWireViewModel property if it has not been set to false, and call OnNavigatingTo in your ViewModel.

#### Getting Started

Be sure to leave the Navigation in App.OnInitialized alone. You will want to always navigate to the Splash Screen as you will use this to ensure you have some starter data and authenticate in the Boss Level. When Navigating from the Splash Screen be sure to use an Absolute Navigation string as this will reset the Navigation Stack (removing the Splash Screen), making your MainPage the Root Page. You will be navigating first to the `BreweriesPage`, this will list all of the breweries that are in the Realm Database. When you tap on a Brewery you will navigate to a TabbedPage with tabs for the BreweryDetailPage and BreweryBeersPage. Next you will Navigate to the BeerPage when a Beer has been tapped in the BreweryBeersPage. When Navigating to the BeerPage from the BreweryBeers page be sure to specify `useModalNavigation: false`. This will ensure that you are able to use the NavigationPage's built in Navigation Bar to go back to the TabbedPage

## Level 1

- Update the menu option to add a new Brewery in the MainPage. Note that the Command Parameter must be set equal to the Navigation Key for your Add Brewery Page
- Add a simple form to add the Brewery to the Realm Mobile Database and return to the Breweries Page

### Notes

You are able to bind directly to properties of a Model. You can look at the included View's like the BeerPage for an example of how to do this. Be sure to create a new instance of the Brewer model in the ViewModel constructor, and bind to it's properties. Then on save you can add it to the Realm.

The Brewer includes a property called InBusinessSince. This is a DateTimeOffset, however we only look at the year. You can use a DatePicker or use an Entry with the Converter included in the Project. Be sure to set an initial value for this property.

## Level 2

- Update the menu option to add a beer, make sure the CommandParameter matches the Navigation Key
- Add a basic view to add a new beer

### Notes

- You will need to set the Brewery the beer is for.
- You can use a Picker using the ItemsSource with a ObservableRangeCollection of all of the Brewers. You can bind to the SelectedItem and set the ItemDisplayBinding to fix the string displayed in the Picker

## Boss Level

- Create a Realm Object Server on Amazon EC2, Azure, or Digital Ocean
- Update the RealmConfiguration in the AppConstants to provide a SyncConfiguration
- Connect your mobile app to the Realm Object Server
- Watch as you make a change on one device and it pops up on another device.

### Notes

- After your Realm Object Server is deployed write down the IP address of the server and navigate to {ip address}:9080. 
- The first time you go to the Dashboard you will be prompted to create an Admin account
- Rename the secrets.json.sample to secrets.json and update the two properties with your Server's IP Address
- Update the RealmConfiguration to return a SyncConfiguration in AppConstants
- Be sure to Login with your user credentials prior to the Seed method in the Splash Screen
- The login will use the AuthUrl, while your configuration will use the RealmServer
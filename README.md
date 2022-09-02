# DnnJobPostings
Simple DNN Job Postings Module Extension

## Module Development Example
This Module is an example for extending DNN (formerly DotNetNuke).

## Development Setup
To clone this repository, first setup the scaffolding.  It uses @UpendoVentures yeoman generator-upendodnn.  To run it, install yeoman `npm install -g yo`. Then install Yarn `npm install -g yarn`. And finally, install the generator `npm install -g generator-upendodnn`. 

Generate the scaffold in the a folder with `yo upendodnn`. Select Solution Structure from the list and answer the questions.  Once complete, go to the Modules folder and clone this repo there `git clone https://github.com/yog-it/DnnJobPostings.git`. Optionally install the latest version of DNN into the Website folder of the scaffold. 

To compile and create the install package, open the Visual Studio project and build in release.  The install package will be in the /Website/Installs/Module folder along with a "symbols" package for debugging.  If DNN is installed in the Website folder the package will be available to install from persona bar Settings > Extensions and select Available Extensions. 

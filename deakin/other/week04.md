Use Case 7: Austroads Vehicle Classification
Objective: Develop an image classification system to accurately classify vehicles into Austroads vehicle categories using collected image data.

Overview: This project aims to create an automated system capable of leveraging computer vision techniques to classify vehicles based on the Austroads vehicle classification scheme.By analysing real-world images captured from diverse sources, the system aims to provide valuable insights into traffic composition, These insights will aid in making informed decisions for traffic management, urban planning, and infrastructure development,

Data Source: For this project, the dataset will be prepared by collecting a diverse and comprehensive set of real-world images capturing vehicles in various environmental and situational contexts, It is crucial to ensure accurate labelling that reflects the diverse vehicle types and configurations present in the dataset

And here is the beginning of Task 7's group chat for Vehicle Classification.
Link to the Planner: https://tasks.office.com/deakin365.onmicrosoft.com/en-US/Home/Planner/#/plantaskboard?groupId=a3977aab-e4c1-4a33-8fd8-b0e7f10b979c&planId=ie9wg4qvlU-QAh1Gh5892MgABmBd
Link to the group's Github directory: https://github.com/Chameleon-company/MOP-Code/tree/master/artificial-intelligence/Vehicle%20Classification

Conclusion: By implementing an image classification system for Austroads vehicle
categories, Melbourne can utilize advanced computer vision techniques to optimize traffic
management strategies, enhance road safety measures, and support sustainable urban
development. This approach not only facilitates efficient transportation networks but also
contributes to improving the overall quality of life for residents and visitors by ensuring
safer and more streamlined traffic operations.

How to create a branch in AI
git clone https://github.com/Chameleon-company/MOP-Code.git
cd MOP-Code
cd artificial-intelligence
cd “your use case folder”
git checkout -b yourName
(change your name into the branch name you have enroll in the case)
mv “directory to of your work” “directory of your folder you have clone”
git add .
git commit -m "your comment what you have done"
git push origin yourName

Requirements:

Create two folders for training and val:
There must be two sub-folders (images and labels) inside each file:

Data Acquisition:

• Collect data for Sedan: 120–150 images in the train folder and 30–40 images in the val folder.

• Collect data for Carriage: 120–150 images in the train folder and 30–40 images in the val folder.

• Collect data for 4WD: 120–150 images in the train folder and 30–40 images in the val folder.

• Collect data for Utility: 120–150 images in the train folder and 30–40 images in the val folder.

• Collect data for Light Van: 120–150 images in the train folder and 30–40 images in the val folder.

• Collect data bicycles: 120–150 images in the train folder, 30–40 images in the val folder.

• Collect data motorcycles: 120–150 images in the train folder, 30–40 images in the val folder.

All images must contain a file text to store the location of the object. This file text will be stored in the labels folder

Please download the txt file below to annotate the object
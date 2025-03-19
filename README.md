# Limitless Wheels

_Some examples are shown below but you should expand on each subtitle as much as needed to provide comprehensive information/ **MarkDown** reference is available here: <https://www.markdownguide.org/basic-syntax/>_

Include the name, logo and images refering to your project

![{Your App XR} logo](./docs/example-image.jpg)

## Introduction

Limitless Wheels is an innovative XR experience designed for individuals in wheelchairs who can move their upper bodies. The goal of this experience is to provide a sense of freedom and rehabilitation by allowing users to practice daily tasks in a safe and controlled environment. Many individuals in wheelchairs need to relearn independent living, and Limitless Wheels offers a way to engage in these activities in an immersive virtual space.

## Design Process

[_Add evidence on the general overview of how you planned, designed, and developed your project, including the goals, challenges, and solutions._]

For example:
x- Brainstorming: A screenshot of the whiteboard or post-it notes used to land the project's idea.
x- User Research: Pictures and summary of how you conducted user research, such as surveys, interviews, or observations, and what insights you gained from it.
- User Persona: A description of your target user, their needs, motivations, and pain points, and how your project addresses them.
- User Journey: A visualization of how your user interacts with your project, from the initial trigger to the final outcome, and what emotions they experience along the way.
- Wireframes and Prototypes: A collection of sketches, mockups, or prototypes that show the layout, structure, and functionality of your project, and how you tested and iterated on them.

Many wheelchair users face challenges when adapting to everyday life. They need to practice mobility and interaction within their living spaces while maintaining independence. The lack of engaging, hands-free virtual rehabilitation tools motivated the development of this experience.

### Target Users
- Individuals who use wheelchairs but retain upper-body mobility.
- People undergoing rehabilitation to regain independence in daily activities.
- Users seeking a virtual environment for safe mobility training.

#### Needs
- A controlled environment to practice daily tasks.
- An intuitive and immersive experience without requiring controllers.
- A system that encourages independence and boosts confidence.

#### Motivations
- The desire to regain control over daily life activities.
- A fun, engaging way to practice mobility and hand coordination.
- Increased accessibility in virtual rehabilitation experiences.

#### Pain Points
- Traditional rehabilitation exercises can be repetitive and uninspiring.
- Many VR applications require hand controllers, limiting accessibility.
- A lack of real-life scenario training in standard rehabilitation programs.


## System description

### Features
- Virtual Apartment: A realistic, interactive space where users perform everyday tasks.
- Eye-Tracking Navigation: Users move by looking at directional arrows, freeing their hands for interactions.
- Hands-Free Object Interaction: A touch and grabbable system in Unity allows natural object manipulation.
- Task Completion System: Tasks like setting the table and organizing objects reinforce rehabilitation and independence.
- End-of-Experience Event: A rewarding conclusion signaled by a doorbell, reinforcing accomplishment.

#### Navigation System
The movement system is designed to be completely hands-free using an eye-tracking interface. Users look at directional arrows to move along the horizontal axis. This system provides:
- Intuitive Movement without requiring controllers.
- Focus on Tasks rather than on navigation mechanics.
- Increased Accessibility for individuals with limited hand function.

#### Object Interaction System
Using a Touch & Grabbable System in Unity, users can:
- Pick up and move objects naturally.
- Interact with items in a realistic manner.
- Precisely place objects where needed.

Watch the demo video or try the live version.

Link: <https://extralitylab.dsv.su.se/>

## Installation

[_Installation process to build and run your project. Use code blocks, tables, or lists to show the commands, steps, or requirements the chosen platform. Mention any dependencies or libraries that your project uses and how to install them._]

This section outlines the steps to set up your environment for developing Android VR applications using Unity 2022.3 or higher:



### Installing Meta Software
1. Create Meta account: <https://developers.meta.com/horizon/>
2. Download and install Meta Quest Developer Hub: <https://developers.meta.com/horizon/documentation/unity/ts-odh/>
3. Download and install Meta Quest Link (only useful if you use Windows and you have a laptop with dedicated graphics card compatible with VR): <https://www.meta.com/engb/help/quest/1517439565442928/>

### Installing Unity Editor and Configuring XR Packages
1. Create a Unity ID: <https://unity.com/>
2. Download and install Unity Hub from Link: <https://unity.com/download>
3. Download and install Unity Editor LTS (Recommended version: v2022.3.XX (any minor version)): <https://unity.com/releases/editor/archive>
4. Follow the instructions to complete the Unity Editor installation.
5. You need to manage your license: choose a free personal license

### Configuring a Unity Project for Meta Quest Development
1. Create empty project: Choose the template 3D (URP)
2. Switch build platform: Choose the platform Android
3. Import Meta XR SDKs (com.meta.xr.sdk.all)

### Configure XR in Project Settings
1. In Project Settings, in the section XR Plugin Management, install the plugin.
2. In the section XR Plugin Management: choose the tab with the Android icon, and tick the Oculus Plug-in provider. Then, also choose the tab with the Desktop icon, and tick Oculus
3. Click on the Meta XR option on the left menu Click on Fix All

### Add an XR Camera
1. Remove the Main Camera.
2. Add a Camera Rig object to the scene.

### Build your XR App
1. File > Build Settings
2. You should see the Android version
3. Press Build and select a name for the requested .apk file

### You also need to install the following dependencies or libraries for your project:

- Library A - a Unity plugin for building VR and AR experiences
- Library B - a C# wrapper for speech recognition and synthesis

## Usage

[_Usage section showing how to use your project and interact with its features. You can use examples, screenshots, gifs, or videos to demonstrate the user interface, controls, and feedback of your project. You can also provide tips, tricks, or best practices for using your project effectively._]

To use [Your App XR} and interact with its features, follow the guidelines below:

- To move around, use the touchpad or the joystick on your controller, or swipe on your phone screen.
- To select ...a planet or a moon, point at it with your controller or your phone, or gaze at it with your headset.
- To zoom in or out, use the trigger or the button on your controller, or pinch on your phone screen.
- To access the information panel, press...
- To use voice commands, say "OK" followed by one of the following phrases:
  - "Show me [X]" - to show X element
  - "Close window Y" - to close window Y
  
Some tips, tricks, and best practices for using [Your App XR} effectively:

- Tip 1
- Tip 2


## References

Acknowledge here the sources, references, or inspirations that you used for your project. Give credit to the original authors or creators of the materials that you used or adapted for your project (3D models, source code, audio effects, etc.)

## Contributors
Jacopo Levati: <https://www.linkedin.com/in/jacopo-levati-335a1224b?lipi=urn%3Ali%3Apage%3Ad_flagship3_profile_view_base_contact_details%3B8%2BRihYZHQqGImBcDq6%2FxRQ%3D%3D>

The authors of the project, contact information, and links to their websites or portfolios.

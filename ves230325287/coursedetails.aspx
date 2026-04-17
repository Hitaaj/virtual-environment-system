<%@ Page Title="Course Details" Language="C#" MasterPageFile="~/vesmaster.Master" AutoEventWireup="true" CodeBehind="coursedetails.aspx.cs" Inherits="ves230325287.coursedetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <!-- page title -->
    <section class="page-title-section overlay" data-background="images/backgrounds/page-title.jpg">
        <div class="container">
            <div class="row">
                <div class="col-md-8">
                    <ul class="list-inline custom-breadcrumb">
                        <li class="list-inline-item"><a class="h2 text-primary font-secondary" href="courses.html">Our Courses</a></li>
                        <li class="list-inline-item text-white h3 font-secondary nasted">Photography</li>
                    </ul>
                    <p class="text-lighten">Our courses offer a good compromise between the continuous assessment favoured by some universities and the emphasis placed on final exams by others.</p>
                </div>
            </div>
        </div>
    </section>
    <!-- /page title -->

    <!-- section -->
    <section class="section-sm">
        <div class="container">
            <div class="row">
                <div class="col-12 mb-4">
                    <!-- course thumb -->
                    <img src="images/photography.jpeg" class="img-fluid w-100">
                </div>
            </div>
            <!-- course info -->
            <div class="row align-items-center mb-5">
                <div class="col-xl-3 order-1 col-sm-6 mb-4 mb-xl-0">
                    <h2>Photography</h2>
                </div>
                <div class="col-xl-6 order-sm-3 order-xl-2 col-12 order-2">
                    <ul class="list-inline text-xl-center">
                        <li class="list-inline-item mr-4 mb-3 mb-sm-0">
                            <div class="d-flex align-items-center">
                                <i class="ti-book text-primary icon-md mr-2"></i>
                                <div class="text-left">
                                    <h6 class="mb-0">COURSES</h6>
                                    <p class="mb-0">06 Month</p>
                                </div>
                            </div>
                        </li>
                        <li class="list-inline-item mr-4 mb-3 mb-sm-0">
                            <div class="d-flex align-items-center">
                                <i class="ti-alarm-clock text-primary icon-md mr-2"></i>
                                <div class="text-left">
                                    <h6 class="mb-0">DURATION</h6>
                                    <p class="mb-0">03 Hours</p>
                                </div>
                            </div>
                        </li>
                        <li class="list-inline-item mr-4 mb-3 mb-sm-0">
                            <div class="d-flex align-items-center">
                                <i class="ti-wallet text-primary icon-md mr-2"></i>
                                <div class="text-left">
                                    <h6 class="mb-0">FEE</h6>
                                    <p class="mb-0">From: $699</p>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <div class="col-xl-3 text-sm-right text-left order-sm-2 order-3 order-xl-3 col-sm-6 mb-4 mb-xl-0">
                    <a href="#" class="btn btn-primary">Apply now</a>
                </div>
                <!-- border -->
                <div class="col-12 mt-4 order-4">
                    <div class="border-bottom border-primary"></div>
                </div>
            </div>
            <!-- course details -->
            <div class="row">
                <div class="col-12 mb-4">
                    <h3>About Course</h3>
                    <p>"Embark on a captivating journey into the world of photography with our comprehensive course designed for both beginners and enthusiasts alike. Led by seasoned professionals, our program offers a twelve-week immersive experience, providing participants with the fundamental skills and techniques necessary to capture stunning images and unleash their creative potential. From mastering the intricacies of camera operation to exploring composition principles and lighting fundamentals, each session is meticulously crafted to equip students with the knowledge and confidence to excel in their photographic endeavors. Whether aspiring to pursue photography as a career or simply seeking to hone their artistic skills, our course promises to ignite passion, foster creativity, and cultivate a lifelong appreciation for the art of visual storytelling."</p>
                </div>
                <div class="col-12 mb-4">
                    <h3 class="mb-3">Requirements</h3>
                    <div class="col-12 px-0">
                        <div class="row">
                            <div class="col-md-6">
                                <ul class="list-styled">
                                    <li>Memory Cards: Adequate memory cards to store captured images during class sessions and field assignments.</li>
                                    <li>Laptop/Desktop Computer: Access to a personal computer for post-processing work, including editing and organizing captured images using software like Adobe Lightroom or Photoshop.</li>
                                    <li>Basic Photography Knowledge: While not mandatory, a basic understanding of photography concepts such as aperture, shutter speed, ISO, and composition can be advantageous.</li>
                                    <li>Digital Camera: Students must have access to a digital camera, preferably a DSLR or mirrorless camera, to participate in practical sessions and assignments.</li>
                                </ul>
                            </div>
                            <div class="col-md-6">
                                <ul class="list-styled">
                                    <li>Mobile Phone with Camera: While not a substitute for a dedicated camera, a smartphone with a camera can be used for certain exercises and to explore the principles of composition and framing.

                                    </li>
                                    <li>Memory Card Reader: A memory card reader for transferring images from the camera's memory card to a computer for post-processing.</li>
                                    <li>Lens: Along with the camera body, students should have at least one lens suitable for various types of photography, such as a standard zoom lens (e.g., 24-70mm) or a prime lens (e.g., 50mm).</li>
                                    <li>Tripod: A sturdy tripod is essential for stability during long exposure shots and to ensure sharpness in images.</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
             
                <div class="col-12 mb-5">
                    <h3>Fees and Funding</h3>
                    <p>
                        Certainly! Here's a paragraph providing information on the fees and funding for the photography course:

"Our photography course offers competitive tuition fees designed to provide exceptional value for the comprehensive learning experience we offer. The total course fee of $800 covers all instructional materials, access to specialized equipment during practical sessions, and administrative costs. We understand that funding can be a concern for some students, and we strive to provide various options to support their educational journey. Scholarships, grants, and flexible payment plans are available for eligible candidates, allowing individuals to pursue their passion for photography without financial barriers. Additionally, students may explore external funding opportunities such as government-sponsored schemes or private scholarships to supplement their tuition fees. Our dedicated financial aid team is available to assist students in navigating these options and finding the best solution to support their academic goals."
                    </p>
                </div>
                <!-- teacher -->
                <div class="col-12">
                    <h5 class="mb-3">Tutor</h5>
                    <div class="d-flex justify-content-between align-items-center flex-wrap">
                        <div class="media mb-2 mb-sm-0">
                            <img class="mr-4 img-fluid" src="images/teacher.jpg" alt="Teacher">
                            <div class="media-body">
                                <h4 class="mt-0">John Doe</h4>
                               
                            </div>
                        </div>
                        <div class="social-link">
                            <h6 class="d-none d-sm-block">Social Link</h6>
                            <ul class="list-inline">
                                <li class="list-inline-item"><a class="d-inline-block text-light p-1" href="#"><i class="ti-facebook"></i></a></li>
                                <li class="list-inline-item"><a class="d-inline-block text-light p-1" href="#"><i class="ti-twitter-alt"></i></a></li>
                                <li class="list-inline-item"><a class="d-inline-block text-light p-1" href="#"><i class="ti-linkedin"></i></a></li>
                                <li class="list-inline-item"><a class="d-inline-block text-light p-1" href="#"><i class="ti-instagram"></i></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="border-bottom border-primary mt-4"></div>
                </div>
            </div>
        </div>
    </section>
    <!-- /section -->

</asp:Content>

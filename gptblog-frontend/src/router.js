import {createRouter, createWebHashHistory} from "vue-router/dist/vue-router";
import AboutUs from "@/components/AboutUs";
import SignIn from "@/components/SignIn";
import SignUp from "@/components/SignUp";
import UserProfile from "@/components/UserProfile";
import WritePost from "@/components/WritePost";
import PostsComponent from "@/components/PostsComponent";
import WelcomeComponent from "@/components/WelcomeComponent";

export default createRouter({
    history: createWebHashHistory(),
    routes: [
        {path: "/index", component: WelcomeComponent, alias: "/"},
        {path: "/about", component: AboutUs, alias: "/"},
        {path: "/sign-in", component: SignIn},
        {path: "/sign-up", component: SignUp},
        {path: "/profile", component: UserProfile},
        {path: "/write-post", component: WritePost},
        {path: "/posts", component: PostsComponent},
    ]
})